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
        public async Task<List<PromediosGeneros>> GetPromedioAgricultura()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GenerosAgro", sql))
                {
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
                total = (int)reader["total"],
                cantidad = (int)reader["cantidad"],


            };
        }
        //Termina la funcion asincrona para agro

        //Funcion asincrona que se usa para llamar el stored procedure para promedio de generos de ganaderia
        public async Task<List<PromediosGeneros>> GetPromedioGanaderia()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GenerosGanaderia", sql))
                {
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
                total = (int)reader["total"],
                cantidad = (int)reader["cantidad"],


            };
        }
        //Termina la funcion asincrona para ganaderia

    }
}
