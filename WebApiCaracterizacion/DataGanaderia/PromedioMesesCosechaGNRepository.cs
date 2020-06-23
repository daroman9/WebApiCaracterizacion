using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsGanaderia;

namespace WebApiCaracterizacion.DataGanaderia
{
    public class PromedioMesesCosechaGNRepository
    {
        private readonly string _connectionString;
        public PromedioMesesCosechaGNRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosMesesCosechaGN>> GetPromedio(string plantilla, string tipoConsulta, string incluyeCultivo, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.IAG_MesesCosecha", sql))
                {
                    cmd.Parameters.Add("@plantilla", SqlDbType.VarChar).Value = (object)plantilla ?? DBNull.Value;
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@incluyeCultivo", SqlDbType.VarChar).Value = (object)incluyeCultivo ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosMesesCosechaGN>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {
                            if (plantilla == null & tipoConsulta == "municipio" & incluyeCultivo == "s")
                            {
                                response.Add(Case1(reader));
                            }
                            else if (plantilla == null & tipoConsulta == "municipio" & incluyeCultivo == null)
                            {
                                response.Add(Case2(reader));
                            }
                            else if (plantilla == null & tipoConsulta == "general" & incluyeCultivo == "s")
                            {
                                response.Add(Case3(reader));
                            }
                            else if (plantilla == null & tipoConsulta == "general" & incluyeCultivo == null)
                            {
                                response.Add(Case4(reader));
                            }
                            else if (plantilla != null & tipoConsulta == "municipio" & incluyeCultivo == "s")
                            {
                                response.Add(Case5(reader));
                            }
                            else if (plantilla != null & tipoConsulta == "municipio" & incluyeCultivo == null)
                            {
                                response.Add(Case6(reader));
                            }
                            else if (plantilla != null & tipoConsulta == "general" & incluyeCultivo == "s")
                            {
                                response.Add(Case7(reader));
                            }
                            else if (plantilla != null & tipoConsulta == "general" & incluyeCultivo == null)
                            {
                                response.Add(Case8(reader));
                            }
                        }
                    }

                    return response;
                }
            }
        }


        private PromediosMesesCosechaGN Case1(SqlDataReader reader)
        {
            return new PromediosMesesCosechaGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                cultivo_principal = (string)reader["cultivo_principal"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }

        private PromediosMesesCosechaGN Case2(SqlDataReader reader)
        {
            return new PromediosMesesCosechaGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }

        private PromediosMesesCosechaGN Case3(SqlDataReader reader)
        {
            return new PromediosMesesCosechaGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                cultivo_principal = (string)reader["cultivo_principal"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
        private PromediosMesesCosechaGN Case4(SqlDataReader reader)
        {
            return new PromediosMesesCosechaGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
        private PromediosMesesCosechaGN Case5(SqlDataReader reader)
        {
            return new PromediosMesesCosechaGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                cultivo_principal = (string)reader["cultivo_principal"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
        private PromediosMesesCosechaGN Case6(SqlDataReader reader)
        {
            return new PromediosMesesCosechaGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
        private PromediosMesesCosechaGN Case7(SqlDataReader reader)
        {
            return new PromediosMesesCosechaGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                cultivo_principal = (string)reader["cultivo_principal"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
        private PromediosMesesCosechaGN Case8(SqlDataReader reader)
        {
            return new PromediosMesesCosechaGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }

    }
}