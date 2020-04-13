using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Data
{
    public class PromedioGenerosRepository
    {
        private readonly string _connectionString;
        public PromedioGenerosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        //Funcion asincrona que se usa para llamar el stored procedure para promedio de generos de agro
        public async Task<List<PromediosGeneros>> GetPromedioAgricultura(string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GenerosAgro", sql))
                {
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;

                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosGeneros>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValueAgro(reader));
                        }
                    }

                    return response;
                }
            }
        }
        private PromediosGeneros MapToValueAgro(SqlDataReader reader)
        {
            return new PromediosGeneros()
            {
                genero = (string)reader["genero"],
                municipio = (string)reader["municipio"],
                total = (int)reader["total"],
                cantidad = (int)reader["cantidad"],
            };
        }
        //Termina la funcion asincrona para agro

        //Funcion asincrona que se usa para llamar el stored procedure para promedio de generos de ganaderia
        public async Task<List<PromediosGeneros>> GetPromedioGanaderia(string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GenerosGanaderia", sql))
                {
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value =(object)fechaInicio?? DBNull.Value;
        
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value =(object)fechaFin?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosGeneros>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValueGanaderia(reader));
                        }
                    }

                    return response;
                }
            }
        }
        private PromediosGeneros MapToValueGanaderia(SqlDataReader reader)
        {
            return new PromediosGeneros()
            {
                genero = (string)reader["genero"],
                municipio = (string)reader["municipio"],
                total = (int)reader["total"],
                cantidad = (int)reader["cantidad"],


            };
        }
        //Termina la funcion asincrona para ganaderia


        //Funcion asincrona que se usa para llamar el stored procedure para promedio de generos de transporte fluvial
        public async Task<List<PromediosGeneros>> GetPromedioTransporte(string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GenerosTransporte", sql))
                {
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;

                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosGeneros>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValueTransporte(reader));
                        }
                    }

                    return response;
                }
            }
        }
        private PromediosGeneros MapToValueTransporte(SqlDataReader reader)
        {
            return new PromediosGeneros()
            {
                genero = (string)reader["genero"],
                municipio = (string)reader["municipio"],
                total = (int)reader["total"],
                cantidad = (int)reader["cantidad"],


            };
        }
        //Termina la funcion asincrona para transporte fluvial

    }
}
