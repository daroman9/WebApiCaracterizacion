using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsGanaderia;

namespace WebApiCaracterizacion.DataGanaderia
{
    public class PromedioNombreAsociacionGNRepository
    {
        private readonly string _connectionString;
        public PromedioNombreAsociacionGNRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosNombreAsociacionGN>> GetPromedio(string plantilla, string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.IAG_NombreAsociacion", sql))
                {
                    cmd.Parameters.Add("@plantilla", SqlDbType.VarChar).Value = (object)plantilla ?? DBNull.Value;
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosNombreAsociacionGN>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {
                            if (plantilla == null & tipoConsulta == "general")
                            {
                                response.Add(MapToValueNullGeneral(reader));
                            }
                            else if (plantilla == null & tipoConsulta == "municipio")
                            {
                                response.Add(MapToValueNullMunicipio(reader));
                            }
                            else if (plantilla != null & tipoConsulta == "general")
                            {
                                response.Add(MapToValueGeneral(reader));
                            }
                            else if (plantilla != null & tipoConsulta == "municipio")
                            {
                                response.Add(MapToValue(reader));
                            }
                        }
                    }

                    return response;
                }
            }
        }
        private PromediosNombreAsociacionGN MapToValue(SqlDataReader reader)
        {
            return new PromediosNombreAsociacionGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
        private PromediosNombreAsociacionGN MapToValueNullMunicipio(SqlDataReader reader)
        {
            return new PromediosNombreAsociacionGN()
            {

                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
        private PromediosNombreAsociacionGN MapToValueGeneral(SqlDataReader reader)
        {
            return new PromediosNombreAsociacionGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
        private PromediosNombreAsociacionGN MapToValueNullGeneral(SqlDataReader reader)
        {
            return new PromediosNombreAsociacionGN()
            {
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
    }
}