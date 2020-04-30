﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Data
{
    public class PromedioViviendaTFRepository
    {
        private readonly string _connectionString;
        public PromedioViviendaTFRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosViviendaTF>> GetPromedio(string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PromedioViviendaTF", sql))
                {
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosViviendaTF>();
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
        private PromediosViviendaTF MapToValue(SqlDataReader reader)
        {
            return new PromediosViviendaTF()
            {
                municipio = (string)reader["municipio"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
        private PromediosViviendaTF MapToValueGeneral(SqlDataReader reader)
        {
            return new PromediosViviendaTF()
            {
                porcentaje = (double)reader["porcentaje"]
            };

        }

    }
}