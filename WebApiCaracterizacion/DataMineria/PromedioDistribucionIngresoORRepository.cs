using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsMineria;

namespace WebApiCaracterizacion.DataMineria
{
    public class PromedioDistribucionIngresoORRepository
    {
        private readonly string _connectionString;
        public PromedioDistribucionIngresoORRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosDistribucionIngresosOR>> GetPromedio(string plantilla, string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.IM_DistribucionIngresos", sql))
                {
                    cmd.Parameters.Add("@plantilla", SqlDbType.VarChar).Value = (object)plantilla ?? DBNull.Value;
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosDistribucionIngresosOR>();
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

        private PromediosDistribucionIngresosOR MapToValueNullGeneral(SqlDataReader reader)
        {
            return new PromediosDistribucionIngresosOR()
            {

                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]


            };
        }

        private PromediosDistribucionIngresosOR MapToValueNullMunicipio(SqlDataReader reader)
        {
            return new PromediosDistribucionIngresosOR()
            {
                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }

        private PromediosDistribucionIngresosOR MapToValueMunicipio(SqlDataReader reader)
        {
            return new PromediosDistribucionIngresosOR()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }

        private PromediosDistribucionIngresosOR MapToValueGeneral(SqlDataReader reader)
        {
            return new PromediosDistribucionIngresosOR()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }

    }
}
