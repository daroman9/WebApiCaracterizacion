using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Data
{
    public class PromedioBeneficiariosRepository
    {
        private readonly string _connectionString;
        public PromedioBeneficiariosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        //Funcion asincrona que se usa para llamar el stored procedure
        public async Task<List<PromediosBeneficiarios>> GetPromedio(string tipoConsulta,string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PromediosBeneficiarios", sql))
                {
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosBeneficiarios>();
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
        private PromediosBeneficiarios MapToValue(SqlDataReader reader)
        {
            return new PromediosBeneficiarios()
            {
  
                beneficiario = (string)reader["beneficiario"],
                cantidad = (int)reader["cantidad"],
                aspecto = (string)reader["aspecto"],
                municipio = (string)reader["municipio"],
               

            };
        }
        private PromediosBeneficiarios MapToValueGeneral(SqlDataReader reader)
        {
            return new PromediosBeneficiarios()
            {
                beneficiario = (string)reader["beneficiario"],
                cantidad = (int)reader["cantidad"]
            };
        }
 

    }
}
