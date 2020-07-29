using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebApiCaracterizacion.ModelsConsultasGenerales;
using System;
using System.Data;

namespace WebApiCaracterizacion.DataConsultasGenerales
{
    public class UsersAndFormsRepostitory
    {
        private readonly string _connectionString;
        public UsersAndFormsRepostitory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<UsersAndForms>> GetData(string documento)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.UsersAndForms", sql))
                {
                    cmd.Parameters.Add("@documento", SqlDbType.VarChar).Value = (object)documento ?? DBNull.Value;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<UsersAndForms>();
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
        private UsersAndForms MapToValue(SqlDataReader reader)
        {
            return new UsersAndForms()
            {
                nombre = (string)reader["nombre"],
                apellido = (string)reader["apellido"],
                documento = (int)reader["documento"],
                email = (string)reader["email"],
                rol = (int)reader["rol"],
                fecha_inicio = (DateTime)reader["fecha_inicio"],
                fecha_fin = (DateTime)reader["fecha_fin"],
                nombreCampaña = (string)reader["nombreCampaña"],
                id_plantilla = (int)reader["id_plantilla"],
                id_usuario = (string)reader["id_usuario"]
            };
        }

    }
}