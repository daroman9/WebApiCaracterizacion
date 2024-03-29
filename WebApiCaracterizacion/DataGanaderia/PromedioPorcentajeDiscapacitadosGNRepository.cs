﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsGanaderia;

namespace WebApiCaracterizacion.DataGanaderia
{
    public class PromedioPorcentajeDiscapacitadosGNRepository
    {
        private readonly string _connectionString;
        public PromedioPorcentajeDiscapacitadosGNRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosPorcentajeDiscpacitadosGN>> GetPromedio(string plantilla, string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.IAG_ActividadPrimariaPredio", sql))
                {
                    cmd.Parameters.Add("@plantilla", SqlDbType.VarChar).Value = (object)plantilla ?? DBNull.Value;
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosPorcentajeDiscpacitadosGN>();
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
        private PromediosPorcentajeDiscpacitadosGN MapToValue(SqlDataReader reader)
        {
            return new PromediosPorcentajeDiscpacitadosGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                promedio = (double)reader["promedio"]

            };
        }
        private PromediosPorcentajeDiscpacitadosGN MapToValueNullMunicipio(SqlDataReader reader)
        {
            return new PromediosPorcentajeDiscpacitadosGN()
            {

                municipio = (string)reader["municipio"],
                promedio = (double)reader["promedio"]
            };
        }
        private PromediosPorcentajeDiscpacitadosGN MapToValueGeneral(SqlDataReader reader)
        {
            return new PromediosPorcentajeDiscpacitadosGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                promedio = (double)reader["promedio"]
            };
        }
        private PromediosPorcentajeDiscpacitadosGN MapToValueNullGeneral(SqlDataReader reader)
        {
            return new PromediosPorcentajeDiscpacitadosGN()
            {
                promedio = (double)reader["promedio"]
            };
        }
    }
}