using LoginV1.DataAccess;
using LoginV1.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginV1.Controller
{
    internal class UsuarioController
    {
        public Usuario Login(string username, string password)
        {
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Usuarios WHERE Username = @Username AND Password = @Password AND estado_cuenta = 1";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id = reader.GetInt32(0),
                                NombreCompleto = reader.GetString(1),
                                Username = reader.GetString(7),
                                Password = reader.GetString(8),
                                TipoUsuario = reader.GetString(6),
                                Correo = reader.GetString(3),
                                Estado = reader.GetInt32(9) == 1
                            };
                        }
                    }
                }
            }
            
            return null; // Usuario no encontrado
        }
    }
}
