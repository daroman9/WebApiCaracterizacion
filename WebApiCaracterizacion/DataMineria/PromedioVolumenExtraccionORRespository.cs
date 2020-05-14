using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsMineria;
namespace WebApiCaracterizacion.DataMineria
{
    public class PromedioVolumenExtraccionORRespository
    {
        private readonly string _connectionString;
        public PromedioVolumenExtraccionORRespository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosVolumenExtraccionOR>> GetPromedio(string plantilla, string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.IM_VolumenExtraccion", sql))
                {
                    cmd.Parameters.Add("@plantilla", SqlDbType.VarChar).Value = (object)plantilla ?? DBNull.Value;
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosVolumenExtraccionOR>();
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
                            else if (plantilla == "5" & tipoConsulta == "municipio")
                            {
                                response.Add(MapToValueMunicipio(reader));
                            }
                            else if (plantilla == "5" & tipoConsulta == "general")
                            {
                                response.Add(MapToValueGeneral(reader));
                            }
                        }
                    }

                    return response;
                }
            }
        }

        private PromediosVolumenExtraccionOR MapToValueNullGeneral(SqlDataReader reader)
        {
            return new PromediosVolumenExtraccionOR()
            {
                promedio = (double)reader["promedio"]
            };
        }

        private PromediosVolumenExtraccionOR MapToValueNullMunicipio(SqlDataReader reader)
        {
            return new PromediosVolumenExtraccionOR()
            {
                municipio = (string)reader["municipio"],
                promedio = (double)reader["promedio"]
            };
        }

        private PromediosVolumenExtraccionOR MapToValueMunicipio(SqlDataReader reader)
        {
            return new PromediosVolumenExtraccionOR()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                promedio = (double)reader["promedio"]
            };
        }

        private PromediosVolumenExtraccionOR MapToValueGeneral(SqlDataReader reader)
        {
            return new PromediosVolumenExtraccionOR()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                promedio = (double)reader["promedio"]
            };
        }
    }
}