using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsConsultasGenerales;
using System;
using System.Data;

namespace WebApiCaracterizacion.DataConsultasGenerales
{
    public class FiltrarFichasRepository
    {
        private readonly string _connectionString;
        public FiltrarFichasRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<FiltrarFichas>> GetPromedio(string rol, string idUser, string tipoFiltro, string aspecto,
            string codigo, string fechaInicio, string fechaFin, string email)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.FiltroFichas", sql))
                {
                    cmd.Parameters.Add("@rol", SqlDbType.VarChar).Value = (object)rol ?? DBNull.Value;
                    cmd.Parameters.Add("@idUser", SqlDbType.VarChar).Value = (object)idUser ?? DBNull.Value;
                    cmd.Parameters.Add("@tipoFiltro", SqlDbType.VarChar).Value = (object)tipoFiltro ?? DBNull.Value;
                    cmd.Parameters.Add("@aspecto", SqlDbType.VarChar).Value = (object)aspecto ?? DBNull.Value;
                    cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = (object)codigo ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = (object)fechaInicio ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = (object)fechaFin ?? DBNull.Value;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = (object)email ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<FiltrarFichas>();
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
        private FiltrarFichas MapToValue(SqlDataReader reader)
        {
            return new FiltrarFichas()
            {
                fecha_ficha = (DateTime)reader["fecha_ficha"],
                nombre_aspecto = (string)reader["nombre_aspecto"],
                codigo_ficha = (string)reader["codigo_ficha"],
                nombre = (string)reader["nombre"],
                apellido = (string)reader["apellido"],
                email = (string)reader["email"],
                nombre_campana = (string)reader["nombre_campana"],
                id_ficha = (string)reader["id_ficha"],
                estado = (int)reader["estado"]
            };
        }
  
    }
}