using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using LoginV1.Models;
using LoginV1.DataAccess;
using System.Security.Cryptography.X509Certificates;

namespace LoginV1.Controller
{
    public class PrestamoController
    {
        public bool RegistrarPrestamo(Prestamo prestamo)
        {
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Prestamos (id_usuario, fecha_prestamo, fecha_estimada_devolucion, estado) VALUES (@id_usuario, @fecha_prestamo, @fecha_estimada_devolucion, @Estado)";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id_usuario", prestamo.IdUsuario);
                    cmd.Parameters.AddWithValue("@fecha_prestamo", prestamo.FechaInicio);
                    cmd.Parameters.AddWithValue("@fecha_estimada_devolucion", prestamo.FechaFin);
                    cmd.Parameters.AddWithValue("@estado", prestamo.Estado);
                    return cmd.ExecuteNonQuery() > 0;
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
                    cmd.Parameters.AddWithValue("@fecha_prestamo", prestamo.FechaInicio);
                    cmd.Parameters.AddWithValue("@fecha_estimada_devolucion", prestamo.FechaFin);
                    cmd.Parameters.AddWithValue("@Estado", prestamo.Estado);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Prestamo> ObtenerPrestamos()
        {
            var prestamos = new List<Prestamo>();
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Prestamos";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        prestamos.Add(new Prestamo
                        {
                            Id = reader.GetInt32(0),
                            IdUsuario = reader.GetInt32(1),
                            IdLibro = reader.GetInt32(2),
                            FechaInicio = reader.GetDateTime(3),
                            FechaFin = reader.GetDateTime(4),
                            Estado = reader.GetInt32(5)
                        });
                    }
                }
            }
            return prestamos;
        }
    }
}
