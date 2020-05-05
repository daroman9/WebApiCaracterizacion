using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Data
{
    public class PromedioEstadoTFRepository
    {
        private readonly string _connectionString;
        public PromedioEstadoTFRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosEstadosTF>> GetPromedio(string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.ITF_EstadoCivil", sql))
                {
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosEstadosTF>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {

                            if (tipoConsulta == "general")
                            {
                                response.Add(MapToValueGeneral(reader));
                            }
                            else
                            {
                                response.Add(MapToValue(reader));
                            }

                        }
                    }

                    return response;
                }
            }
        }
        private PromediosEstadosTF MapToValue(SqlDataReader reader)
        {
            string municipio;
            string dato;
            int cantidad;
            double porcentaje;

            if(reader["municipio"] == DBNull.Value)
            {
                municipio = "NA";
            }
            else
            {
                municipio = (string)reader["municipio"];
            };

            if (reader["dato"] == DBNull.Value)
            {
                dato = "NA";
            }
            else
            {
                dato = (string)reader["dato"];
            };

            if (reader["cantidad"] == DBNull.Value)
            {
                cantidad = 0;
            }
            else
            {
                cantidad = (int)reader["cantidad"];
            };
            if (reader["porcentaje"] == DBNull.Value)
            {
                porcentaje = 0;
            }
            else
            {
                porcentaje = (double)reader["porcentaje"];
            };


            return new PromediosEstadosTF()
            {
          
               municipio = municipio,
               dato = dato,
               cantidad = cantidad,
               porcentaje = porcentaje
            };
        }
        private PromediosEstadosTF MapToValueGeneral(SqlDataReader reader)
        {      
            string dato;
            int cantidad;
            double porcentaje;

            if (reader["dato"] == DBNull.Value)
            {
                dato = "NA";
            }
            else
            {
                dato = (string)reader["dato"];
            };

            if (reader["cantidad"] == DBNull.Value)
            {
                cantidad = 0;
            }
            else
            {
                cantidad = (int)reader["cantidad"];
            };
            if (reader["porcentaje"] == DBNull.Value)
            {
                porcentaje = 0;
            }
            else
            {
                porcentaje = (double)reader["porcentaje"];
            };
            return new PromediosEstadosTF()
            {
                dato = dato,
                cantidad = cantidad,
                porcentaje = porcentaje
            };

        }

    }
}