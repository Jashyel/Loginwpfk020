using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loginwpfk020.Datos
{
    internal class UsuariosDao
    {
        private const string ConnString = "server=(localdb)\\MSSQLLocalDB;database=proyectok20;Trusted_Connection=True";
        private const string sqlLogin = "select * from usuarios where username = @nombreUsuario;";
        public Usuario buscarUsuarioPorUsername(String username, string password)
        {
            Usuario user = null;
            using(SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConnString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = sqlLogin;
                command.Connection = connection;
                SqlParameter usernameParameter =
                    new SqlParameter("@nombreUsuario", username);
                command.Parameters.Add(usernameParameter);
                SqlDataReader dr = command.ExecuteReader();
                Console.WriteLine("Se encontraron registros" + dr.HasRows);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if(password == dr.GetString("password"))
                        { 
                        user = new Usuario();
                        user.Id = dr.GetInt32("id");
                        user.Username = username;
                        user.Password = dr.GetString("password");
                        user.NombreCompleto = dr.GetString(3);
                            break;
                        }
                    }
                }


            }
               return user;
        }
    }
}
