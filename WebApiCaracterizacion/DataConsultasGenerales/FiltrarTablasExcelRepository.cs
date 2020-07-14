using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsConsultasGenerales;
using System;
using System.Data;

namespace WebApiCaracterizacion.DataConsultasGenerales
{
    public class FiltrarTablasExcelRepository
    {
        private readonly string _connectionString;
        public FiltrarTablasExcelRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<FiltrarTablasExcel>> GetPromedio(string tipoFiltro, string aspecto,
            string codigo, string fechaInicio, string fechaFin, string email)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.FiltroRegistrosTablaExcel", sql))
                {
                    cmd.Parameters.Add("@tipoFiltro", SqlDbType.VarChar).Value = (object)tipoFiltro ?? DBNull.Value;
                    cmd.Parameters.Add("@aspecto", SqlDbType.VarChar).Value = (object)aspecto ?? DBNull.Value;
                    cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = (object)codigo ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = (object)email ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<FiltrarTablasExcel>();
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
        private FiltrarTablasExcel MapToValue(SqlDataReader reader)
        {
            string dato_string;
            string dato_float;
            string dato_integer;
            string dato_date;


            if (reader["valor_string"] == DBNull.Value)
            {
                dato_string = "";
            }
            else
            {
                dato_string = (string)reader["valor_string"];
            };

            if (reader["valor_float"] == DBNull.Value)
            {
                dato_float = Convert.ToString("");
            }
            else
            {
                dato_float = Convert.ToString(reader["valor_float"]);
            };

            if (reader["valor_integer"] == DBNull.Value)
            {
                dato_integer = Convert.ToString("");
            }
            else
            {
                dato_integer = Convert.ToString(reader["valor_integer"]);
            };


            if (reader["valor_date"] == DBNull.Value)
            {
                dato_date = Convert.ToString("");
            }
            else
            {
                dato_date = Convert.ToString(reader["valor_date"]);
            };


            return new FiltrarTablasExcel()
            {

                valor_string = dato_string,
                valor_float = dato_float,
                valor_integer = dato_integer,
                valor_date = dato_date,
                fecha = (DateTime)reader["fecha"],
                id_column = (string)reader["id_column"],
                row = (string)reader["row"],
                id_campo = (int)reader["id_campo"],
                id_ficha = (string)reader["id_ficha"]

            };
        }

    }
}