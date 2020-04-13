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
    public class PromedioEscolaridadRepository
    {
        private readonly string _connectionString;
        public PromedioEscolaridadRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        //Funcion asincrona que se usa para llamar el stored procedure para promedio de generos de agro
        public async Task<List<PromediosEscolaridad>> GetPromedioAgricultura(string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("EscolaridadAgro", sql))
                {
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;

                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosEscolaridad>();
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
        private PromediosEscolaridad MapToValueAgro(SqlDataReader reader)
        {
            return new PromediosEscolaridad()
            {
                escolaridad = (string)reader["escolaridad"],
                municipio = (string)reader["municipio"],
                total = (int)reader["total"],
                cantidad = (int)reader["cantidad"],
            };
        }
        //Termina la funcion asincrona para agro

    }
}