﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsMineria;

namespace WebApiCaracterizacion.DataMineria
{
    public class PromedioVolumenDiarioAgregadosORRepository
    {
        private readonly string _connectionString;
        public PromedioVolumenDiarioAgregadosORRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosVolumenDiarioAgregadosOR>> GetPromedio(string plantilla, string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.IM_VolumenDiarioAgregados", sql))
                {
                    cmd.Parameters.Add("@plantilla", SqlDbType.VarChar).Value = (object)plantilla ?? DBNull.Value;
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosVolumenDiarioAgregadosOR>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {

                     
                             if (plantilla == "5" & tipoConsulta == "zona")
                            {
                                response.Add(MapToValueMunicipio(reader));
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
        private PromediosVolumenDiarioAgregadosOR MapToValueMunicipio(SqlDataReader reader)
        {
            return new PromediosVolumenDiarioAgregadosOR()
            {
                dato = (string)reader["dato"],
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                valor = (double)reader["valor"],
                orden = (double)reader["orden"],
                color = (string)reader["color"],
                nombre_campana = (string)reader["nombre_campana"],
                tipo_grafica = (string)reader["tipo_grafica"]
            };
        }

        private PromediosVolumenDiarioAgregadosOR MapToValueGeneral(SqlDataReader reader)
        {
            return new PromediosVolumenDiarioAgregadosOR()
            {
                dato = (string)reader["dato"],
                tipo_plantilla = (string)reader["tipo_plantilla"],
                valor = (double)reader["valor"],
                orden = (double)reader["orden"],
                color = (string)reader["color"],
                nombre_campana = (string)reader["nombre_campana"],
                tipo_grafica = (string)reader["tipo_grafica"]
            };
        }

    }
}