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
        private readonly FacturaService _facturaService = new FacturaService();

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
                            TituloLibro = reader.GetString(6),
                            ISBN = reader.GetString(7),
                            FechaPrestamo = DateTime.Parse(reader.GetString(8)),
                            FechaLimite = DateTime.Parse(reader.GetString(9)),
                            FechaDevolucionReal = reader.IsDBNull(10) ? (DateTime?)null : DateTime.Parse(reader.GetString(10)),
                            DiasRetraso = reader.GetInt32(11),
                            TarifaDiaria = Convert.ToDecimal(reader.GetDouble(12)),
                            MontoTotal = Convert.ToDecimal(reader.GetDouble(13)),
                            Estado = reader.GetString(14),
                            FechaPago = reader.IsDBNull(15) ? (DateTime?)null : DateTime.Parse(reader.GetString(15)),
                            FechaCreacion = DateTime.Parse(reader.GetString(16))
                        });
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Obtiene una única multa por su ID.
        /// </summary>
        public MultaDetalle ObtenerTodas(int idMulta)
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
                                TituloLibro = reader.GetString(6),
                                ISBN = reader.GetString(7),
                                FechaPrestamo = DateTime.Parse(reader.GetString(8)),
                                FechaLimite = DateTime.Parse(reader.GetString(9)),
                                FechaDevolucionReal = reader.IsDBNull(10) ? (DateTime?)null : DateTime.Parse(reader.GetString(10)),
                                DiasRetraso = reader.GetInt32(11),
                                TarifaDiaria = Convert.ToDecimal(reader.GetDouble(12)),
                                MontoTotal = Convert.ToDecimal(reader.GetDouble(13)),
                                Estado = reader.GetString(14),
                                FechaPago = reader.IsDBNull(15) ? (DateTime?)null : DateTime.Parse(reader.GetString(15)),
                                FechaCreacion = DateTime.Parse(reader.GetString(16))
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void GenerarMultasVencidas()
        {
            using (var conn = SQLiteConnectionManager.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {

                    // Inserta una multa por cada préstamo vencido, activo y que aún no tenga multa
                    const string sqlInsert = @"
                      INSERT INTO Multas (
                        id_prestamo,
                        dias_retraso,
                        tarifa_diaria,
                        monto_total,
                        estado,
                        fecha_creacion
                      )
                      SELECT
                        p.id_prestamo,
                        CAST(julianday('now') - julianday(p.fecha_estimada_devolucion) AS INTEGER) AS dias_retraso,
                        @TarifaDiaria AS tarifa_diaria,
                        CAST((julianday('now') - julianday(p.fecha_estimada_devolucion)) * @TarifaDiaria AS NUMERIC) AS monto_total,
                        'Pendiente' AS estado,
                        DATETIME('now') AS fecha_creacion
                      FROM Prestamos p
                      LEFT JOIN Multas m 
                        ON m.id_prestamo = p.id_prestamo
                      WHERE
                        -- 1) Fecha de devolución estimada ya pasó
                        p.fecha_estimada_devolucion < DATE('now')
                        -- 2) El libro aún no fue devuelto
                        AND p.fecha_devolucion IS NULL
                        -- 3) Y todavía no existe multa para ese préstamo
                        AND m.id_multa IS NULL; ";

                    using (var cmd = new SQLiteCommand(sqlInsert, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@TarifaDiaria", 1500m);  // o el valor que definas
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                }
            }
        }



        /// <summary>
        /// Marca una multa como pagada, registrando la fecha de pago y actualizando su estado.
        /// </summary>
        public bool MarcarComoPagada(int idMulta, decimal monto, DateTime fechaPago)
        {
            using (var conn = SQLiteConnectionManager.GetConnection())
            {
                conn.Open();
                const string sql = @"
                    UPDATE Multas
                    SET
                        -- Si monto_total > monto abonado, se resta, sino queda 0
                        monto_total = CASE
                            WHEN monto_total > @Monto THEN monto_total - @Monto
                            ELSE 0
                        END,

                        -- Estado: 'Pendiente' si queda saldo, 'Pagada' si saldo cero
                        estado = CASE
                            WHEN monto_total > @Monto THEN 'Pendiente'
                            ELSE 'Pagada'
                        END,

                        -- Fecha de pago solo se registra cuando se cubre todo el monto
                        fecha_pago = CASE
                            WHEN monto_total > @Monto THEN fecha_pago
                            ELSE @FechaPago
                        END
                    WHERE id_multa = @Id;
                    ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Monto", monto);
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


        public bool EditarMulta(Multa multa)
        {
            using (var conn = SQLiteConnectionManager.GetConnection())
            {
                conn.Open();
                const string sql = @"
                    UPDATE Multas
                    SET
                        id_prestamo = @IdPrestamo,
                        dias_retraso = @DiasRetraso,
                        tarifa_diaria = @TarifaDiaria,
                        monto_total = @MontoTotal,
                        estado = @Estado,
                        fecha_pago = CASE
                            WHEN @FechaPago IS NULL THEN fecha_pago
                            ELSE @FechaPago
                        END,
                        fecha_creacion = @FechaCreacion
                    WHERE id_multa = @Id;";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", multa.Id);
                    cmd.Parameters.AddWithValue("@IdPrestamo", multa.IdPrestamo);
                    cmd.Parameters.AddWithValue("@DiasRetraso", multa.DiasRetraso);
                    cmd.Parameters.AddWithValue("@TarifaDiaria", multa.TarifaDiaria);
                    cmd.Parameters.AddWithValue("@MontoTotal", multa.MontoTotal);
                    cmd.Parameters.AddWithValue("@Estado", multa.Estado);
                    cmd.Parameters.AddWithValue("@FechaPago", multa.FechaPago == DateTime.MinValue ? (object)DBNull.Value : multa.FechaPago);
                    cmd.Parameters.AddWithValue("@FechaCreacion", multa.FechaCreacion.ToString("yyyy-MM-dd HH:mm:ss"));
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


        /// <summary>
        /// Registra el pago total de la multa y genera su factura en PDF.
        /// </summary>
        /// <param name="idMulta">ID de la multa a pagar.</param>
        /// <param name="montoPago">Monto abonado (debe ser >= monto_total actual).</param>
        /// <returns>Ruta completa del PDF generado, o null si hubo error.</returns>
        public string PagarMultaYGenerarFactura(int idMulta, decimal montoPago)
        {
            // 1. Primero, obtenemos el detalle actual de la multa
            var detalle = ObtenerTodas(idMulta);
            if (detalle == null)
                throw new InvalidOperationException($"No existe la multa con ID {idMulta}.");

            // 2. Verificamos que el pago cubre el monto total
            if (montoPago < detalle.MontoTotal)
                throw new InvalidOperationException("El pago no cubre el total de la multa.");

            // 3. Marcamos la multa como pagada
            bool ok = MarcarComoPagada(idMulta, montoPago, DateTime.Now);
            if (!ok)
                throw new Exception("Error al registrar el pago de la multa.");

            // 4. Obtenemos de nuevo el detalle (ahora con Estado="Pagada" y FechaPago)
            detalle = ObtenerTodas(idMulta);

            // 5. Generamos la factura PDF
            string rutaPdf = _facturaService.GenerarFacturaMulta(detalle);

            // 6. (Opcional) Guardar la ruta en la base de datos
            GuardarRutaFactura(idMulta, rutaPdf);

            return rutaPdf;
        }

        // Replacing "using var" with traditional using statement to ensure compatibility with C# 7.3  
        private void GuardarRutaFactura(int idMulta, string rutaPdf)
        {
            using (var conn = SQLiteConnectionManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(@"
                   UPDATE Multas
                      SET ruta_factura = @RutaPdf
                    WHERE id_multa = @Id;", conn))
                {
                    cmd.Parameters.AddWithValue("@RutaPdf", rutaPdf);
                    cmd.Parameters.AddWithValue("@Id", idMulta);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }

}
