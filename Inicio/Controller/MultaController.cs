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
    internal class MultaController
    {
        public List<Multa> ObtenerMultas()
        {
            var multas = new List<Multa>();
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Multas";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        multas.Add(new Multa
                        {
                            Id = reader.GetInt32(0),
                            IdPrestamo = reader.GetInt32(1),
                            DiasRetraso = reader.GetInt32(2),
                            TarifaDiaria = Convert.ToDecimal(reader.GetDouble(3)),
                            MontoTotal = Convert.ToDecimal(reader.GetDouble(4)),
                            Estado = reader.GetString(5),
                            FechaPago = (DateTime)(reader.IsDBNull(6) ? (DateTime?)null : DateTime.Parse(reader.GetString(6))),
                        });
                    }
                }
            }
            return multas;
        }
        public List<Multa> ObtenerMultas(string consulta)
        {
            var multas = new List<Multa>();
            using (var connection = SQLiteConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Multas WHERE UsuarioId LIKE @Consulta";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Consulta", "%" + consulta + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            multas.Add(new Multa
                            {
                                Id = reader.GetInt32(0),
                                IdPrestamo = reader.GetInt32(1),
                                DiasRetraso = reader.GetInt32(2),
                                TarifaDiaria = Convert.ToDecimal(reader.GetDouble(3)),
                                MontoTotal = Convert.ToDecimal(reader.GetDouble(4)),
                                Estado = reader.GetString(5),
                                FechaPago = (DateTime)(reader.IsDBNull(6) ? (DateTime?)null : DateTime.Parse(reader.GetString(6))),
                            });
                        }
                    }
                }
            }
            return multas;
        }

        public List<MultaDetalle> ObtenerTodas()
        {
            var lista = new List<MultaDetalle>();

            using (var conn = SQLiteConnectionManager.GetConnection())
            {
                conn.Open();
                const string sql = "SELECT * FROM vista_multas_detalle;";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new MultaDetalle
                        {
                            IdMulta = reader.GetInt32(0),
                            IdPrestamo = reader.GetInt32(1),
                            IdUsuario = reader.GetInt32(2),
                            NombreUsuario = reader.GetString(3),
                            DocumentoIdentidad = reader.GetString(4),
                            TipoUsuario = reader.GetString(5),
                            TituloLibro = reader.GetString(7),
                            ISBN = reader.GetString(8),
                            FechaPrestamo = DateTime.Parse(reader.GetString(9)),
                            FechaLimite = DateTime.Parse(reader.GetString(10)),
                            FechaDevolucionReal = reader.IsDBNull(11) ? (DateTime?)null : DateTime.Parse(reader.GetString(11)),
                            DiasRetraso = reader.GetInt32(12),
                            TarifaDiaria = Convert.ToDecimal(reader.GetDouble(13)),
                            MontoTotal = Convert.ToDecimal(reader.GetDouble(14)),
                            Estado = reader.GetString(15),
                            FechaPago = reader.IsDBNull(16) ? (DateTime?)null : DateTime.Parse(reader.GetString(16)),
                            FechaCreacion = DateTime.Parse(reader.GetString(17))
                        });
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Obtiene una única multa por su ID.
        /// </summary>
        public MultaDetalle ObtenerPorId(int idMulta)
        {
            using (var conn = SQLiteConnectionManager.GetConnection())
            {
                conn.Open();
                const string sql = @"
                    SELECT * 
                      FROM vista_multas_detalle 
                     WHERE id_multa = @Id;";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", idMulta);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new MultaDetalle
                            {
                                IdMulta = reader.GetInt32(0),
                                IdPrestamo = reader.GetInt32(1),
                                IdUsuario = reader.GetInt32(2),
                                NombreUsuario = reader.GetString(3),
                                DocumentoIdentidad = reader.GetString(4),
                                TipoUsuario = reader.GetString(5),
                                TituloLibro = reader.GetString(7),
                                ISBN = reader.GetString(8),
                                FechaPrestamo = DateTime.Parse(reader.GetString(9)),
                                FechaLimite = DateTime.Parse(reader.GetString(10)),
                                FechaDevolucionReal = reader.IsDBNull(11) ? (DateTime?)null : DateTime.Parse(reader.GetString(11)),
                                DiasRetraso = reader.GetInt32(12),
                                TarifaDiaria = Convert.ToDecimal(reader.GetDouble(13)),
                                MontoTotal = Convert.ToDecimal(reader.GetDouble(14)),
                                Estado = reader.GetString(15),
                                FechaPago = reader.IsDBNull(16) ? (DateTime?)null : DateTime.Parse(reader.GetString(16)),
                                FechaCreacion = DateTime.Parse(reader.GetString(17))
                            };
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Marca una multa como pagada, registrando la fecha de pago y actualizando su estado.
        /// </summary>
        public bool MarcarComoPagada(int idMulta, DateTime fechaPago)
        {
            using (var conn = SQLiteConnectionManager.GetConnection())
            {
                conn.Open();
                const string sql = @"
                    UPDATE Multas 
                       SET estado     = 'Pagada',
                           fecha_pago = @FechaPago
                     WHERE id_multa  = @Id;";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FechaPago", fechaPago.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Id", idMulta);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Registra una nueva multa a partir de los datos de un objeto MultaDetalle o Multa.
        /// </summary>
        public bool AgregarMulta(int idPrestamo, int diasRetraso, decimal tarifaDiaria)
        {
            var montoTotal = diasRetraso * tarifaDiaria;
            var fechaCreacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using (var conn = SQLiteConnectionManager.GetConnection())
            {
                conn.Open();
                const string sql = @"
                    INSERT INTO Multas (
                        id_prestamo,
                        dias_retraso,
                        tarifa_diaria,
                        monto_total,
                        estado,
                        fecha_creacion
                    ) VALUES (
                        @IdPrestamo,
                        @DiasRetraso,
                        @TarifaDiaria,
                        @MontoTotal,
                        'Pendiente',
                        @FechaCreacion
                    );";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
                    cmd.Parameters.AddWithValue("@DiasRetraso", diasRetraso);
                    cmd.Parameters.AddWithValue("@TarifaDiaria", tarifaDiaria);
                    cmd.Parameters.AddWithValue("@MontoTotal", montoTotal);
                    cmd.Parameters.AddWithValue("@FechaCreacion", fechaCreacion);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Elimina una multa de la base de datos.
        /// </summary>
        public bool EliminarMulta(int idMulta)
        {
            using (var conn = SQLiteConnectionManager.GetConnection())
            {
                conn.Open();
                const string sql = "DELETE FROM Multas WHERE id_multa = @Id;";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", idMulta);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }

}
