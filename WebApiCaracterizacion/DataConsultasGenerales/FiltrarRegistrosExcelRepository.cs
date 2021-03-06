﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsConsultasGenerales;
using System;
using System.Data;

namespace WebApiCaracterizacion.DataConsultasGenerales
{
    public class FiltrarRegistrosExcelRepository
    {
        private readonly string _connectionString;
        public FiltrarRegistrosExcelRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<FiltrarRegistrosExcel>> GetPromedio(string tipoFiltro, string aspecto,
            string codigo, string fechaInicio, string fechaFin, string email)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.FiltroRegistrosExcel", sql))
                {
                    cmd.Parameters.Add("@tipoFiltro", SqlDbType.VarChar).Value = (object)tipoFiltro ?? DBNull.Value;
                    cmd.Parameters.Add("@aspecto", SqlDbType.VarChar).Value = (object)aspecto ?? DBNull.Value;
                    cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = (object)codigo ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = (object)email ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<FiltrarRegistrosExcel>();
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
        private FiltrarRegistrosExcel MapToValue(SqlDataReader reader)
        {
            string dato_string;
            string dato_float;
            string dato_integer;
            string dato_date;
            string fechaNula;
            DateTime dato_fecha;
    

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
                dato_float =Convert.ToString("");
            }
            else
            {
                dato_float =Convert.ToString(reader["valor_float"]);
            };

            if (reader["valor_integer"] == DBNull.Value)
            {
                dato_integer =Convert.ToString("");
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

            if (reader["fecha"] == DBNull.Value)
            {

                fechaNula = null;

                dato_fecha = Convert.ToDateTime(fechaNula);

            }
            else
            {
                dato_fecha = Convert.ToDateTime(reader["fecha"]);
            };



            return new FiltrarRegistrosExcel()
            {

             valor_string = dato_string,
             valor_float = dato_float,
             valor_integer = dato_integer,
             valor_date = dato_date,
             fecha = dato_fecha,
             id_campo = (int)reader["id_campo"],
             id_ficha = (string)reader["id_ficha"]
               
            };
        }

    }
}