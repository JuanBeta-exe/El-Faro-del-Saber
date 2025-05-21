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
            using (var conn = SQLiteConnectionManager.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    //try
                    {
                        // 1. Insertar préstamo principal
                        var cmd = new SQLiteCommand(@"
                            INSERT INTO Prestamos (
                            id_usuario,
                            fecha_prestamo,
                            fecha_estimada_devolucion,
                            estado,
                            fecha_creacion
                            ) VALUES (
                            @Usuario, @Inicio, @Fin, 'Activo', DATETIME('now')
                            );", conn);
                        cmd.Parameters.AddWithValue("@Usuario", prestamo.IdUsuario);
                        cmd.Parameters.AddWithValue("@Inicio", prestamo.FechaPrestamo);
                        cmd.Parameters.AddWithValue("@Fin", prestamo.FechaEstimada);
                        cmd.ExecuteNonQuery();

                        // 2. Obtener ID del préstamo recién insertado
                        cmd = new SQLiteCommand("SELECT last_insert_rowid();", conn);
                        int idPrestamo = Convert.ToInt32(cmd.ExecuteScalar());

                        // 3. Insertar libros relacionados
                        foreach (var idLibro in idsLibros)
                        {
                            var cmdLibro = new SQLiteCommand(@"
                            INSERT INTO Prestamos_Libros (
                                id_prestamo, id_libro, cantidad, estado_ejemplar
                            ) VALUES (
                                @Prestamo, @Libro, 1, 'Prestado'
                            );", conn);
                            cmdLibro.Parameters.AddWithValue("@Prestamo", idPrestamo);
                            cmdLibro.Parameters.AddWithValue("@Libro", idLibro);
                            cmdLibro.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return true;
                    }
                   // catch
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

    }
}
