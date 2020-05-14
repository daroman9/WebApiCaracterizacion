using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsMineria;

namespace WebApiCaracterizacion.DataMineria
{
    public class PromedioMinimoOroORRepository
    {
        private readonly string _connectionString;
        public PromedioMinimoOroORRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosMinimoOroOR>> GetPromedio(string plantilla, string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.IM_CantidadMinimaOro", sql))
                {
                    cmd.Parameters.Add("@plantilla", SqlDbType.VarChar).Value = (object)plantilla ?? DBNull.Value;
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosMinimoOroOR>();
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
                            else if (plantilla == "10" & tipoConsulta == "municipio")
                            {
                                response.Add(MapToValueMunicipio(reader));
                            }
                            else if (plantilla == "10" & tipoConsulta == "general")
                            {
                                response.Add(MapToValueGeneral(reader));
                            }
                            else if (plantilla == "101" & tipoConsulta == "municipio")
                            {
                                response.Add(MapToValueMunicipio(reader));
                            }
                            else if (plantilla == "101" & tipoConsulta == "general")
                            {
                                response.Add(MapToValueGeneral(reader));
                            }
                            else if (plantilla == "102" & tipoConsulta == "municipio")
                            {
                                response.Add(MapToValueMunicipio(reader));
                            }
                            else if (plantilla == "102" & tipoConsulta == "general")
                            {
                                response.Add(MapToValueGeneral(reader));
                            }
                            else if (plantilla == "4" & tipoConsulta == "municipio")
                            {
                                response.Add(MapToValueMunicipio(reader));
                            }
                            else if (plantilla == "4" & tipoConsulta == "general")
                            {
                                response.Add(MapToValueGeneral(reader));
                            }
                            else if (plantilla == "41" & tipoConsulta == "municipio")
                            {
                                response.Add(MapToValueMunicipio(reader));
                            }
                            else if (plantilla == "41" & tipoConsulta == "general")
                            {
                                response.Add(MapToValueGeneral(reader));
                            }
                            else if (plantilla == "42" & tipoConsulta == "municipio")
                            {
                                response.Add(MapToValueMunicipio(reader));
                            }
                            else if (plantilla == "42" & tipoConsulta == "general")
                            {
                                response.Add(MapToValueGeneral(reader));
                            }
                        }
                    }

                    return response;
                }
            }
        }

        private PromediosMinimoOroOR MapToValueNullGeneral(SqlDataReader reader)
        {
            return new PromediosMinimoOroOR()
            {
                promedio = (decimal)reader["promedio"]
            };
        }

        private PromediosMinimoOroOR MapToValueNullMunicipio(SqlDataReader reader)
        {
            return new PromediosMinimoOroOR()
            {
                municipio = (string)reader["municipio"],
                promedio = (decimal)reader["promedio"]
            };
        }

        private PromediosMinimoOroOR MapToValueMunicipio(SqlDataReader reader)
        {
            return new PromediosMinimoOroOR()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                promedio = (decimal)reader["promedio"]
            };
        }

        private PromediosMinimoOroOR MapToValueGeneral(SqlDataReader reader)
        {
            return new PromediosMinimoOroOR()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                promedio = (decimal)reader["promedio"]
            };
        }

    }
}

