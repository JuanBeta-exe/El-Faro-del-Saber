using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginV1.DataAccess;
using LoginV1.Models;
using System.Data.SQLite;

namespace LoginV1.Controller
{
    public class LibroController
    {
        public bool AgregarLibro(Libro libro)
        {
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = @"
                        INSERT INTO Libros (
                        titulo,
                        autor,
                        editorial,
                        isbn,
                        anio_publicacion,
                        id_categoria,
                        cantidad_ejemplares,
                        ejemplares_disponibles,
                        estado,
                        fecha_creacion) 
                        VALUES (
                        @Titulo,
                        @Autor,
                        @Editorial,
                        @ISBN,
                        @AnioPublicacion,
                        @IdCategoria,
                        @CantidadEjemplares,
                        @EjemplaresDisponibles,
                        @Estado,
                        @FechaCreacion
                    );";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    cmd.Parameters.AddWithValue("@Autor", libro.Autor);
                    cmd.Parameters.AddWithValue("@Editorial", libro.Editorial);
                    cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
                    cmd.Parameters.AddWithValue("@AnioPublicacion", libro.AñoPublicacion);
                    cmd.Parameters.AddWithValue("@IdCategoria", libro.Categoria);
                    cmd.Parameters.AddWithValue("@CantidadEjemplares", libro.Cantidad);
                    cmd.Parameters.AddWithValue("@EjemplaresDisponibles", libro.EjemplaresDisponibles);
                    cmd.Parameters.AddWithValue("@Estado", libro.Estado == "Activo" ? 1 : 0); 
                    cmd.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Libro> ObtenerLibros()
        {
            var libros = new List<Libro>();
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Libros";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        libros.Add(new Libro
                        {
                            Id = reader.GetInt32(0),
                            Titulo = reader.GetString(1),
                            Autor = reader.GetString(2),
                            Editorial = reader.IsDBNull(3) ? null : reader.GetString(3),
                            ISBN = reader.GetString(4),
                            AñoPublicacion = reader.GetInt32(5),
                            Categoria = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                            Cantidad = reader.GetInt32(7),
                            EjemplaresDisponibles = reader.GetInt32(8),
                            Estado = reader.GetInt32(9) == 1 ? "Activo" : "Inactivo"
                        });
                    }
                }
            }
            return libros;
        }

        public List<Libro> ObtenerLibroPorId(int id)
        {
            var libros = new List<Libro>();
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Libros WHERE id_libro = @Id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            libros.Add(new Libro
                            {
                                Id = reader.GetInt32(0),
                                Titulo = reader.GetString(1),
                                Autor = reader.GetString(2),
                                Editorial = reader.IsDBNull(3) ? null : reader.GetString(3),
                                ISBN = reader.GetString(4),
                                AñoPublicacion = reader.GetInt32(5),
                                Categoria = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                                Cantidad = reader.GetInt32(7),
                                EjemplaresDisponibles = reader.GetInt32(8),
                                Estado = reader.GetInt32(9) == 1 ? "Activo" : "Inactivo"
                            });
                        }
                    }
                }
            }
            return libros;
        }

        public bool EditarLibro(Libro libro)
        {
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = @"
                    UPDATE Libros 
                    SET 
                        Titulo = @Titulo, 
                        Autor = @Autor, 
                        Editorial = @Editorial, 
                        ISBN = @ISBN,
                        anio_publicacion = @anio_publicacion, 
                        id_categoria = @Categoria,
                        cantidad_ejemplares = @Cantidad,
                        ejemplares_disponibles = @EjemplaresDisponibles,
                        estado = @Estado 
                    WHERE 
                        id_libro = @Id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", libro.Id);
                    cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    cmd.Parameters.AddWithValue("@Autor", libro.Autor);
                    cmd.Parameters.AddWithValue("@Editorial", libro.Editorial);
                    cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
                    cmd.Parameters.AddWithValue("@anio_publicacion", libro.AñoPublicacion);
                    cmd.Parameters.AddWithValue("@Categoria", libro.Categoria);
                    cmd.Parameters.AddWithValue("@Cantidad", libro.Cantidad);
                    cmd.Parameters.AddWithValue("@EjemplaresDisponibles", libro.EjemplaresDisponibles);
                    cmd.Parameters.AddWithValue("@Estado", libro.Estado == "Activo" ? 1 : 0); // Convertir string a int
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarLibro(int id)
        {
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Libros WHERE id_libro = @Id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }

}
