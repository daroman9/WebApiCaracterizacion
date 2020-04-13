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
    public class PromedioViviendasRepository
    {
        private readonly string _connectionString;
        public PromedioViviendasRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        //Funcion asincrona que se usa para llamar el stored procedure para promedio de generos de agro
        public async Task<List<PromediosViviendas>> GetPromedioAgricultura(string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ViviendasAgro", sql))
                {
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;

                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosViviendas>();
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
        private PromediosViviendas MapToValueAgro(SqlDataReader reader)
        {
            return new PromediosViviendas()
            {
                tenencia = (string)reader["tenencia"],
                municipio = (string)reader["municipio"],
                total = (int)reader["total"],
                cantidad = (int)reader["cantidad"],
            };
        }
    

    }
}