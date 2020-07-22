using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsGanaderia;

namespace WebApiCaracterizacion.DataGanaderia
{
    public class PromedioMesesLecheGNRepository
    {
        private readonly string _connectionString;
        public PromedioMesesLecheGNRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosMesesLecheGN>> GetPromedio(string plantilla, string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.IAG_MesesLeche", sql))
                {
                    cmd.Parameters.Add("@plantilla", SqlDbType.VarChar).Value = (object)plantilla ?? DBNull.Value;
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosMesesLecheGN>();
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
        private PromediosMesesLecheGN MapToValue(SqlDataReader reader)
        {
            return new PromediosMesesLecheGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                detalle = (string)reader["detalle"],
                dato = (string)reader["dato"],
                cantidad_si = (int)reader["cantidad_si"],
                porcentaje_si = (double)reader["porcentaje_si"],
                cantidad_no = (int)reader["cantidad_no"],
                porcentaje_no = (double)reader["porcentaje_no"],
                orden = (double)reader["orden"],
                color = (string)reader["color"],
                nombre_campana = (string)reader["nombre_campana"]
            };
        }
        private PromediosMesesLecheGN MapToValueGeneral(SqlDataReader reader)
        {
            return new PromediosMesesLecheGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                detalle = (string)reader["detalle"],
                dato = (string)reader["dato"],
                cantidad_si = (int)reader["cantidad_si"],
                porcentaje_si = (double)reader["porcentaje_si"],
                cantidad_no = (int)reader["cantidad_no"],
                porcentaje_no = (double)reader["porcentaje_no"],
                orden = (double)reader["orden"],
                color = (string)reader["color"],
                nombre_campana = (string)reader["nombre_campana"]
            };
        }
    }
}