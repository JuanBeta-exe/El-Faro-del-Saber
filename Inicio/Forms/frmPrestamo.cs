using LoginV1.Controller;
using LoginV1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginV1.Forms
{
    public partial class frmPrestamo : Form
    {
        private PrestamoController prestamoController = new PrestamoController();
        private string accion;
        public frmPrestamo()
        {
            InitializeComponent();
            this.Load += CargarPrestamos;

            txtConsulta.KeyPress += keyPressNumber; // Asignar el evento KeyPress al TextBox para permitir solo números
        }

        private void CargarPrestamos(object sender, EventArgs e)
        {
            var prestamos = prestamoController.ObtenerPrestamos();
            dtgPrestamos.DataSource = null; // Limpiar el DataGridView
            dtgPrestamos.DataSource = prestamos; // Asignar la lista de préstamos como fuente de datos
            txtConsulta.Clear(); // Limpiar el TextBox de consulta
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            accion = "Agregar";
            frmAccionPrestamo accionPrestamo = new frmAccionPrestamo(accion);
            accionPrestamo.Show();
        }

        private void btnExtender_Click(object sender, EventArgs e)
        {
            accion = "Extender";
            frmAccionPrestamo accionPrestamo = new frmAccionPrestamo(accion);
            accionPrestamo.Show();
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            if (dtgPrestamos.SelectedRows.Count > 0)
            {
                // Obtener el ID del préstamo de la fila seleccionada
                int prestamoId = Convert.ToInt32(dtgPrestamos.SelectedRows[0].Cells["Id"].Value);

                PrestamoController prestamoController = new PrestamoController();
                bool exito = prestamoController.DevolucionPrestamo(prestamoId);

                if (exito)
                {
                    MessageBox.Show("Devolución realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPrestamos(sender, e); // Actualizar la lista de préstamos
                }
                else
                {
                    MessageBox.Show("Error al realizar la devolución.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un préstamo para realizar la devolución.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgPrestamos.SelectedRows.Count > 0)
                {
                    // Obtener el ID del préstamo de la fila seleccionada
                    int id = Convert.ToInt32(dtgPrestamos.SelectedRows[0].Cells["Id"].Value);
                    var prestamo = new Prestamo
                    {
                        Id = id,
                        IdUsuario = Convert.ToInt32(dtgPrestamos.SelectedRows[0].Cells["IdUsuario"].Value),
                        FechaPrestamo = Convert.ToDateTime(dtgPrestamos.SelectedRows[0].Cells["FechaPrestamo"].Value),
                        FechaEstimada = Convert.ToDateTime(dtgPrestamos.SelectedRows[0].Cells["FechaEstimada"].Value),
                        FechaDevolucion = dtgPrestamos.SelectedRows[0].Cells["FechaDevolucion"].Value != DBNull.Value ? (DateTime?)Convert.ToDateTime(dtgPrestamos.SelectedRows[0].Cells["FechaDevolucion"].Value) : null,
                        Estado = dtgPrestamos.SelectedRows[0].Cells["Estado"].Value.ToString()
                    };

                    if (prestamoController.EditarPrestamo(prestamo))
                    {
                        MessageBox.Show("Préstamo editado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPrestamos(sender, e); // Actualizar la lista de préstamos
                    }
                    else
                    {
                        MessageBox.Show("Error al editar el préstamo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un préstamo para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al editar el préstamo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgPrestamos.SelectedRows.Count > 0)
                {
                    // Obtener el ID del préstamo de la fila seleccionada
                    int prestamoId = Convert.ToInt32(dtgPrestamos.SelectedRows[0].Cells["Id"].Value);
                    PrestamoController prestamoController = new PrestamoController();
                    bool exito = prestamoController.EliminarPrestamo(prestamoId);
                    if (exito)
                    {
                        MessageBox.Show("Préstamo eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPrestamos(sender, e); // Actualizar la lista de préstamos
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el préstamo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un préstamo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al eliminar el préstamo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.Show();
            this.Hide();
        }

        private void keyPressNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
                MessageBox.Show("Solo se permiten números.");
            }
        }

        private void ImportarPrestamos_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Archivos CSV (*.csv)|*.csv",
                    Title = "Seleccionar archivo de préstamos"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var prestamosImportados = new List<Prestamo>();
                    var prestamosLibros = new Dictionary<int, List<int>>(); // IdPrestamo temporal, lista de IdLibros
                    int contadorExitos = 0, contadorErrores = 0;

                    using (var reader = new System.IO.StreamReader(openFileDialog.FileName, Encoding.UTF8))
                    {
                        string header = reader.ReadLine(); // Leer encabezado
                        while (!reader.EndOfStream)
                        {
                            string linea = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(linea)) continue;
                            var campos = linea.Split(';');

                            try
                            {
                                // Suponiendo columnas: IdUsuario,FechaPrestamo,FechaEstimada,FechaDevolucion,Estado,IdLibros
                                // IdLibros: separados por ';' (ej: 1;2;3)
                                int idUsuario = int.Parse(campos[0]);
                                DateTime fechaPrestamo = DateTime.Parse(campos[1]);
                                DateTime fechaEstimada = DateTime.Parse(campos[2]);
                                DateTime? fechaDevolucion = string.IsNullOrWhiteSpace(campos[3]) ? (DateTime?)null : DateTime.Parse(campos[3]);
                                string estado = campos[4];
                                var idsLibros = campos[5].Split(';').Select(x => int.Parse(x)).ToList();

                                var prestamo = new Prestamo
                                {
                                    IdUsuario = idUsuario,
                                    FechaPrestamo = fechaPrestamo,
                                    FechaEstimada = fechaEstimada,
                                    FechaDevolucion = fechaDevolucion,
                                    Estado = estado
                                };

                                // Guardar préstamo y libros asociados
                                if (prestamoController.AgregarPrestamo(prestamo, idsLibros))
                                {
                                    contadorExitos++;
                                }
                                else
                                {
                                    contadorErrores++;
                                }
                            }
                            catch
                            {
                                contadorErrores++;
                            }
                        }
                    }

                    MessageBox.Show($"Importación finalizada.\nÉxitos: {contadorExitos}\nErrores: {contadorErrores}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPrestamos(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al importar los préstamos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarPrestamos(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos CSV (*.csv)|*.csv",
                    Title = "Exportar préstamos",
                    FileName = "PrestamosExportados.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var prestamos = prestamoController.ObtenerPrestamos();

                    using (var writer = new System.IO.StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        // Escribir encabezado  
                        writer.WriteLine("Id;IdUsuario;FechaPrestamo;FechaEstimada;FechaDevolucion;Estado");

                        // Escribir datos de préstamos  
                        foreach (var prestamo in prestamos)
                        {
                            writer.WriteLine($"{prestamo.Id};{prestamo.IdUsuario};{prestamo.FechaPrestamo:yyyy-MM-dd};{prestamo.FechaEstimada:yyyy-MM-dd};{(prestamo.FechaDevolucion.HasValue ? prestamo.FechaDevolucion.Value.ToString("yyyy-MM-dd") : "")};{prestamo.Estado}");
                        }
                    }

                    MessageBox.Show("Préstamos exportados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al exportar los préstamos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
