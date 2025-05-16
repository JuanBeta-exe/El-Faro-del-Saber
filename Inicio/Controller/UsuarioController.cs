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
                                DocumentoIdentidad = reader.GetString(2),
                                Direccion = reader.GetString(4),
                                Telefono = reader.GetString(5),
                                Username = reader.GetString(7),
                                Password = reader.GetString(8),
                                TipoUsuario = reader.GetString(6),
                                Correo = reader.GetString(3),
                                Estado = reader.GetInt32(9) == 1 ? "Activo" : "Inactivo",
                            };
                        }
                    }
                }
            }
            
            return null; // Usuario no encontrado
        }

        public List<Usuario> ObtenerUsuarios()
        {
            var usuarios = new List<Usuario>();
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Usuarios";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            Id = reader.GetInt32(0),
                            NombreCompleto = reader.GetString(1),
                            DocumentoIdentidad = reader.GetString(2),
                            Correo = reader.GetString(3),
                            Telefono = reader.GetString(4),
                            Direccion = reader.GetString(5),
                            TipoUsuario = reader.GetString(6),
                            Username = reader.GetString(7),
                            Password = reader.GetString(8),
                            Estado = reader.GetInt32(9) == 1 ? "Activo" : "Inactivo"
                        });
                    }
                }
            }
            return usuarios;
        }

        public List<Usuario> ObtenerUsuarios(string filtro)
        {
            var usuarios = new List<Usuario>();
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Usuarios WHERE username LIKE @Filtro OR id_usuario LIKE @Filtro";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario
                            {
                                Id = reader.GetInt32(0),
                                NombreCompleto = reader.GetString(1),
                                DocumentoIdentidad = reader.GetString(2),
                                Correo = reader.GetString(3),
                                Telefono = reader.GetString(4),
                                Direccion = reader.GetString(5),
                                TipoUsuario = reader.GetString(6),
                                Username = reader.GetString(7),
                                Password = reader.GetString(8),
                                Estado = reader.GetInt32(9) == 1 ? "Activo" : "Inactivo"
                            });
                        }
                    }
                }
            }
            return usuarios;
        }

        public bool AgregarUsuario(Usuario usuario)
        {
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = @"
                    INSERT INTO Usuarios (
                        nombre_completo,
                        documento_identidad,
                        correo,
                        telefono,
                        direccion,
                        tipo_usuario,
                        username,
                        password,
                        estado_cuenta ) 
                        VALUES (
                        @NombreCompleto,
                        @Documento,
                        @Correo,
                        @Telefono,
                        @Direccion,
                        @TipoUsuario,
                        @Username,
                        @Password,
                        @EstadoCuenta );";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Documento", usuario.DocumentoIdentidad);
                    cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                    cmd.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario); 
                    cmd.Parameters.AddWithValue("@Username", usuario.Username);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password); 
                    cmd.Parameters.AddWithValue("@EstadoCuenta", usuario.Estado == "Activo" ? 1 : 0); 
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EditarUsuario(Usuario usuario)
        {
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = @"
                    UPDATE Usuarios 
                    SET 
                        nombre_completo = @NombreCompleto, 
                        documento_identidad = @Documento, 
                        correo = @Correo, 
                        telefono = @Telefono,
                        direccion = @Direccion,
                        tipo_usuario = @TipoUsuario,
                        username = @Username,
                        password = @Password,
                        estado_cuenta = @EstadoCuenta
                    WHERE 
                        id_usuario = @Id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", usuario.Id);
                    cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Documento", usuario.DocumentoIdentidad);
                    cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                    cmd.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                    cmd.Parameters.AddWithValue("@Username", usuario.Username);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@EstadoCuenta", usuario.Estado == "Activo" ? 1 : 0);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarUsuario(int id)
        {
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Usuarios WHERE id_usuario = @Id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
