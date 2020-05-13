using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Data
{
    public class PromedioVulnerabilidadORRepository
    {
        private readonly string _connectionString;
        public PromedioVulnerabilidadORRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosVulnerabilidadOR>> GetPromedio(string plantilla, string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.IM_VulnerabilidadSocioeconomica", sql))
                {
                    cmd.Parameters.Add("@plantilla", SqlDbType.VarChar).Value = (object)plantilla ?? DBNull.Value;
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosVulnerabilidadOR>();
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
                            else if (plantilla == "0" & tipoConsulta == "municipio")
                            {
                                response.Add(MapToValueCeroMunicipio(reader));
                            }
                            else if (plantilla == "0" & tipoConsulta == "general")
                            {
                                response.Add(MapToValueCeroGeneral(reader));
                            }
                            else if (plantilla == "4" & tipoConsulta == "municipio")
                            {
                                response.Add(MapToValueCeroMunicipio(reader));
                            }
                            else if (plantilla == "4" & tipoConsulta == "general")
                            {
                                response.Add(MapToValueCeroGeneral(reader));
                            }
                            else if (plantilla == "5" & tipoConsulta == "municipio")
                            {
                                response.Add(MapToValueCeroMunicipio(reader));
                            }
                            else if (plantilla == "5" & tipoConsulta == "general")
                            {
                                response.Add(MapToValueCeroGeneral(reader));
                            }
                        }
                    }

                    return response;
                }
            }
        }
        private PromediosVulnerabilidadOR MapToValueCeroMunicipio(SqlDataReader reader)
        {
            return new PromediosVulnerabilidadOR()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]


            };
        }
        private PromediosVulnerabilidadOR MapToValueCeroGeneral(SqlDataReader reader)
        {
            return new PromediosVulnerabilidadOR()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]


            };
        }
        private PromediosVulnerabilidadOR MapToValueNullGeneral(SqlDataReader reader)
        {
            return new PromediosVulnerabilidadOR()
            {

                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]


            };
        }

        private PromediosVulnerabilidadOR MapToValueNullMunicipio(SqlDataReader reader)
        {
            return new PromediosVulnerabilidadOR()
            {
                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]


            };
        }
    }
}
