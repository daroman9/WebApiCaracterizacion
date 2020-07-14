using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsGanaderia;

namespace WebApiCaracterizacion.DataGanaderia
{
    public class PromedioAreaSiembraGNRepository
    {
        private readonly string _connectionString;
        public PromedioAreaSiembraGNRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<PromediosAreaSiembraGN>> GetPromedio(string plantilla, string tipoConsulta, string fechaInicio, string fechaFin)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dw.IAG_AreaCultivo", sql))
                {
                    cmd.Parameters.Add("@plantilla", SqlDbType.VarChar).Value = (object)plantilla ?? DBNull.Value;
                    cmd.Parameters.Add("@tipoConsulta", SqlDbType.VarChar).Value = (object)tipoConsulta ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromediosAreaSiembraGN>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {
                            if (plantilla == null & tipoConsulta == "municipio")
                            {
                                response.Add(Case1(reader));
                            }
                            else if (plantilla == null & tipoConsulta == "general")
                            {
                                response.Add(Case2(reader));
                            }
                            else if (plantilla != null & tipoConsulta == "municipio")
                            {
                                response.Add(Case3(reader));
                            }
                            else if (plantilla != null & tipoConsulta == "general")
                            {
                                response.Add(Case4(reader));
                            }
                        }
                    }

                    return response;
                }
            }
        }

        private PromediosAreaSiembraGN Case1(SqlDataReader reader)
        {
            return new PromediosAreaSiembraGN()
            {

                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                suma = (double)reader["suma"],
                orden = (double)reader["orden"],
                color = (string)reader["color"],
                nombre_campana = (string)reader["nombre_campana"]
            };
        }
        private PromediosAreaSiembraGN Case2(SqlDataReader reader)
        {
            return new PromediosAreaSiembraGN()
            {
                dato = (string)reader["dato"],
                suma = (double)reader["suma"],
                orden = (double)reader["orden"],
                color = (string)reader["color"],
                nombre_campana = (string)reader["nombre_campana"]
            };
        }
        private PromediosAreaSiembraGN Case3(SqlDataReader reader)
        {
            return new PromediosAreaSiembraGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                municipio = (string)reader["municipio"],
                dato = (string)reader["dato"],
                suma = (double)reader["suma"],
                orden = (double)reader["orden"],
                color = (string)reader["color"],
                nombre_campana = (string)reader["nombre_campana"]
            };
        }

        private PromediosAreaSiembraGN Case4(SqlDataReader reader)
        {
            return new PromediosAreaSiembraGN()
            {
                tipo_plantilla = (string)reader["tipo_plantilla"],
                dato = (string)reader["dato"],
                suma = (double)reader["suma"],
                orden = (double)reader["orden"],
                color = (string)reader["color"],
                nombre_campana = (string)reader["nombre_campana"]
            };
        }
    }
}