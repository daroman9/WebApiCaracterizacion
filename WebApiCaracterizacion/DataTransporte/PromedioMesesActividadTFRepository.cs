using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsTransporte;

namespace WebApiCaracterizacion.DataTransporte
{
    public class PromedioMesesActividadTFRepository
    {
        private readonly string _connectionString;
        public PromedioMesesActividadTFRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosMesesActividadGN>> GetPromedio(string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.ITF_DistribucionMesesActividad", sql))
                {
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosMesesActividadGN>();
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
        private PromediosMesesActividadGN MapToValue(SqlDataReader reader)
        {
            return new PromediosMesesActividadGN()
            {
                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                cantidad_si = (int)reader["cantidad_si"],
                porcentaje_si = (double)reader["porcentaje_si"],
                cantidad_no = (int)reader["cantidad_no"],
                porcentaje_no = (double)reader["porcentaje_no"],
                orden = (int)reader["orden"],
                color = (string)reader["color"],
                nombre_campana = (string)reader["nombre_campana"]
            };
        }
        private PromediosMesesActividadGN MapToValueGeneral(SqlDataReader reader)
        {
            return new PromediosMesesActividadGN()
            {
                dato = (string)reader["dato"],
                cantidad_si = (int)reader["cantidad_si"],
                porcentaje_si = (double)reader["porcentaje_si"],
                cantidad_no = (int)reader["cantidad_no"],
                porcentaje_no = (double)reader["porcentaje_no"],
                orden = (int)reader["orden"],
                color = (string)reader["color"],
                nombre_campana = (string)reader["nombre_campana"]
            };
        }
    }
}