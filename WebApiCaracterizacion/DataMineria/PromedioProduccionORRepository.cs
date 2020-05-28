using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsMineria;

namespace WebApiCaracterizacion.DataMineria
{
    public class PromedioProduccionORRepository
    {
        private readonly string _connectionString;
        public PromedioProduccionORRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosProduccionOroOR>> GetPromedio()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.IM_ProduccionOro", sql))
                {
                  
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosProduccionOroOR>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {

                           response.Add(MapToValue(reader));
                            
                        }
                    }

                    return response;
                }
            }
        }

        private PromediosProduccionOroOR MapToValue(SqlDataReader reader)
        {
            return new PromediosProduccionOroOR()
            {

                nombre_zona = (string)reader["nombre_zona"],
                tipo_grafica = (string)reader["tipo_grafica"],
                dato = (string)reader["dato"],
                cantidad = (double)reader["cantidad"]
            };
        }


    }
}
