using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using LoginV1.Models;
using LoginV1.DataAccess;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace LoginV1.Controller
{
    public class PrestamoController
    {
        public bool AgregarPrestamo(Prestamo prestamo, List<int> idsLibros)
        {
            // Validaciones básicas
            if (prestamo == null) throw new ArgumentNullException(nameof(prestamo));
            if (idsLibros == null || idsLibros.Count == 0)
                throw new ArgumentException("Debe especificar al menos un libro.", nameof(idsLibros));

            using (var conn = SQLiteConnectionManager.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar el registro de Préstamo principal
                        using (var cmdPrestamo = new SQLiteCommand(@"
                    INSERT INTO Prestamos (
                        id_usuario,
                        fecha_prestamo,
                        fecha_estimada_devolucion,
                        estado,
                        fecha_creacion
                    ) VALUES (
                        @Usuario, @Inicio, @Fin, 'Activo', DATETIME('now')
                    );", conn, tx))
                        {
                            cmdPrestamo.Parameters.AddWithValue("@Usuario", prestamo.IdUsuario);
                            cmdPrestamo.Parameters.AddWithValue("@Inicio", prestamo.FechaPrestamo.ToString("yyyy-MM-dd"));
                            cmdPrestamo.Parameters.AddWithValue("@Fin", prestamo.FechaEstimada.ToString("yyyy-MM-dd"));
                            cmdPrestamo.ExecuteNonQuery();
                        }

                        // 2. Obtener el ID del Préstamo recién insertado
                        int idPrestamo;
                        using (var cmdGetId = new SQLiteCommand("SELECT last_insert_rowid();", conn, tx))
                        {
                            idPrestamo = Convert.ToInt32(cmdGetId.ExecuteScalar());
                        }

                        // 3. Insertar cada libro en Prestamos_Libros
                        foreach (var idLibro in idsLibros)
                        {
                            // Validar que el libro exista
                            using (var cmdCheck = new SQLiteCommand("SELECT COUNT(1) FROM Libros WHERE id_libro = @IdLibro;", conn, tx))
                            {
                                cmdCheck.Parameters.AddWithValue("@IdLibro", idLibro);
                                var exists = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0;
                                if (!exists)
                                    throw new InvalidOperationException($"El libro con ID {idLibro} no existe.");
                            }

                            // Insertar la relación préstamo–libro
                            using (var cmdLibro = new SQLiteCommand(@"
                        INSERT INTO Prestamos_Libros (
                            id_prestamo,
                            id_libro,
                            cantidad,
                            estado_ejemplar
                        ) VALUES (
                            @Prestamo, @Libro, 1, 'Prestado'
                        );", conn, tx))
                            {
                                cmdLibro.Parameters.AddWithValue("@Prestamo", idPrestamo);
                                cmdLibro.Parameters.AddWithValue("@Libro", idLibro);
                                cmdLibro.ExecuteNonQuery();
                            }

                            // 4. (Opcional) Actualizar ejemplares_disponibles en Libros
                            using (var cmdUpd = new SQLiteCommand(@"
                        UPDATE Libros
                           SET ejemplares_disponibles = ejemplares_disponibles - 1
                         WHERE id_libro = @Libro 
                           AND ejemplares_disponibles > 0;", conn, tx))
                            {
                                cmdUpd.Parameters.AddWithValue("@Libro", idLibro);
                                cmdUpd.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        tx.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool DevolucionPrestamo(int idPrestamo)
        {
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Prestamos SET estado = 'Devuelto', fecha_devolucion = @fecha_devolucion WHERE id_prestamo = @id_prestamo";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id_prestamo", idPrestamo);
                    cmd.Parameters.AddWithValue("@fecha_devolucion", DateTime.Now);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool ActualizarPrestamo(Prestamo prestamo)
        {
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Prestamos SET id_usuario = @id_usuario, fecha_prestamo = @fecha_prestamo, fecha_estimada_devolucion = @fecha_estimada_devolucion, Estado = @Estado WHERE id_prestamo = @id_prestamo";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id_prestamo", prestamo.Id);
                    cmd.Parameters.AddWithValue("@id_usuario", prestamo.IdUsuario);
                    cmd.Parameters.AddWithValue("@fecha_prestamo", prestamo.FechaPrestamo);
                    cmd.Parameters.AddWithValue("@fecha_estimada_devolucion", prestamo.FechaDevolucion);
                    cmd.Parameters.AddWithValue("@Estado", prestamo.Estado);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Prestamo> ObtenerPrestamos()
        {
            var lista = new List<Prestamo>();
            const string sql = @"
                SELECT 
                    id_prestamo,
                    id_usuario,
                    fecha_prestamo,
                    fecha_estimada_devolucion,
                    fecha_devolucion,
                    estado
                FROM Prestamos;";

            using (var conn = SQLiteConnectionManager.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearPrestamo(reader));
                    }
                }
            }

            return lista;
        }

        private Prestamo MapearPrestamo(SQLiteDataReader reader)
        {
            return new Prestamo
            {
                Id = reader.GetInt32(0),
                IdUsuario = reader.GetInt32(1),
                //si en tu diseño tienes IdLibro, descomenta y ajusta columna:
                //IdLibro          = reader.GetInt32(reader.GetOrdinal("id_libro")),

                FechaPrestamo = reader.GetDateTime(2),
                FechaEstimada = reader.GetDateTime(3),

                // Asigna null si el campo es DBNull, o el DateTime si no
                FechaDevolucion = reader.IsDBNull(4)
                                    ? (DateTime?)null
                                    : reader.GetDateTime(4),

                Estado = reader.GetString(5)
            };
        }

        public bool EditarPrestamo(Prestamo prestamo)
        {
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = @"
                    UPDATE Prestamos 
                    SET 
                        id_usuario = @id_usuario, 
                        fecha_prestamo = @fecha_prestamo, 
                        fecha_estimada_devolucion = @fecha_estimada_devolucion, 
                        estado = @estado 
                    WHERE id_prestamo = @id_prestamo";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id_prestamo", prestamo.Id);
                    cmd.Parameters.AddWithValue("@id_usuario", prestamo.IdUsuario);
                    cmd.Parameters.AddWithValue("@fecha_prestamo", prestamo.FechaPrestamo);
                    cmd.Parameters.AddWithValue("@fecha_estimada_devolucion", prestamo.FechaEstimada);
                    cmd.Parameters.AddWithValue("@estado", prestamo.Estado);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarPrestamo(int idPrestamo)
        {
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Prestamos WHERE id_prestamo = @id_prestamo";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id_prestamo", idPrestamo);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
