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
    public class PromedioEstadosRespository
    {
        private readonly string _connectionString;
        public PromedioEstadosRespository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }


        //Funcion asincrona que se usa para llamar el stored procedure para promedio de generos de agricultura
        public async Task<List<PromediosEstados>> GetPromedio(string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PromediosEstados", sql))
                {
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosEstados>();
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
        private PromediosEstados MapToValue(SqlDataReader reader)
        {
            return new PromediosEstados()
            {
                estado = (string)reader["estado"],
                cantidad = (int)reader["cantidad"],
                aspecto = (string)reader["aspecto"],
                municipio = (string)reader["municipio"]

            };
        }

        private PromediosEstados MapToValueGeneral(SqlDataReader reader)
        {
            return new PromediosEstados()
            {
                estado = (string)reader["estado"],
                cantidad = (int)reader["cantidad"]
            };
        }

    }
}
