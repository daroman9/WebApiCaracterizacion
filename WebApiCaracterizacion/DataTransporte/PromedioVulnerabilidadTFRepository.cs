using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsTransporte;

namespace WebApiCaracterizacion.DataTransporte
{
    public class PromedioVulnerabilidadTFRepository
    {
        private readonly string _connectionString;
        public PromedioVulnerabilidadTFRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosVulnerabilidadTF>> GetPromedio(string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.ITF_VulnerabilidadSocioeconomica", sql))
                {
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosVulnerabilidadTF>();
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
        private PromediosVulnerabilidadTF MapToValue(SqlDataReader reader)
        {
            return new PromediosVulnerabilidadTF()
            {
                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
        private PromediosVulnerabilidadTF MapToValueGeneral(SqlDataReader reader)
        {
            return new PromediosVulnerabilidadTF()
            {
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
    }
}
