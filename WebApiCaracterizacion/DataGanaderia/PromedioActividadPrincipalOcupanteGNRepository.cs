﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsGanaderia;

namespace WebApiCaracterizacion.DataGanaderia
{
    public class PromedioActividadPrincipalOcupanteGNRepository
    {
        private readonly string _connectionString;
        public PromedioActividadPrincipalOcupanteGNRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosActividadPrincipalOcupanteGN>> GetPromedio(string plantilla, string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.IAG_ActividadPrincipalOcupante", sql))
                {
                    cmd.Parameters.Add("@plantilla", SqlDbType.VarChar).Value = (object)plantilla ?? DBNull.Value;
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosActividadPrincipalOcupanteGN>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {
                            if (plantilla == null & tipoConsulta == "municipio")
                            {
                                response.Add(Case1(reader));
                            }
                            else if (plantilla == null & tipoConsulta == "general")
                            {
                                response.Add(Case2(reader));
                            }
                            else  if (plantilla != null & tipoConsulta == "municipio")
                            {
                                response.Add(Case3(reader));
                            }
                            else if (plantilla !=null & tipoConsulta =="general")
                            {
                                response.Add(Case4(reader));
                            }
                        }
                    }

                    return response;
                }
            }
        }

        private PromediosActividadPrincipalOcupanteGN Case1(SqlDataReader reader)
        {
            return new PromediosActividadPrincipalOcupanteGN()
            {
              
                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
        private PromediosActividadPrincipalOcupanteGN Case2(SqlDataReader reader)
        {
            return new PromediosActividadPrincipalOcupanteGN()
            {
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
        private PromediosActividadPrincipalOcupanteGN Case3(SqlDataReader reader)
        {
            return new PromediosActividadPrincipalOcupanteGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }

        private PromediosActividadPrincipalOcupanteGN Case4(SqlDataReader reader)
        {
            return new PromediosActividadPrincipalOcupanteGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
    }
}