using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsTransporte;

namespace WebApiCaracterizacion.DataTransporte
{
    public class PromedioMenosProductividadTFRepository
    {
        private readonly string _connectionString;
        public PromedioMenosProductividadTFRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosMenosProductividadTF>> GetPromedio(string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.ITF_DistribucionMenosProductividad", sql))
                {
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosMenosProductividadTF>();
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
        private PromediosMenosProductividadTF MapToValue(SqlDataReader reader)
        {
            return new PromediosMenosProductividadTF()
            {
                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                cantidad = (int)reader["cantidad"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
        private PromediosMenosProductividadTF MapToValueGeneral(SqlDataReader reader)
        {
            return new PromediosMenosProductividadTF()
            {
                cantidad = (int)reader["cantidad"],
                dato = (string)reader["dato"],
                porcentaje = (double)reader["porcentaje"]
            };
        }
    }
}