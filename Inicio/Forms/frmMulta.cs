using LoginV1.Controller;
using LoginV1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoginV1.Forms
{
    public partial class frmMulta : Form
    {
        // Controlador y lista local
        private readonly MultaController _multaController = new MultaController();
        private List<MultaDetalle> _listaMultas;

        public frmMulta()
        {
            InitializeComponent();

            // Asigno manejadores
            this.Load += frmMulta_Load;
            dgvMultas.SelectionChanged += dgvMultas_SelectionChanged;
            btnAbonar.Click += btnAbonar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnEditar.Click += btnEditar_Click;
            btnConsultar.Click += btnConsultar_Click;
            txtConsulta.KeyPress += SoloNumeros_KeyPress;
            txtIdMulta.KeyPress += SoloNumeros_KeyPress;
        }

        // 1. Al cargar el formulario, traigo todas las multas
        private void frmMulta_Load(object sender, EventArgs e)
        {
            CargarMultas();
        }

        // 2. Botón “Consultar” (puede recargar o aplicar filtro de texto encima)
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtConsulta.Text))
            {
                var filtro = _multaController.ObtenerTodas(int.Parse(txtConsulta.Text));
                if (filtro != null)
                {
                    dgvMultas.DataSource = filtro;
                }
                else
                {
                    MessageBox.Show("No se encontraron multas con ese ID.");
                }
            }
            else
            {
                // Recargar todas las multas
                CargarMultas();
            }
            txtConsulta.Clear();
        }

        private void CargarMultas()
        {
            _multaController.GenerarMultasVencidas();

            // Obtiene todas las multas (desde la vista SQL)
            _listaMultas = _multaController.ObtenerTodas();
            dgvMultas.DataSource = _listaMultas;

            // Ajustes visuales básicos
            dgvMultas.Columns["IdMulta"].HeaderText = "ID";
            dgvMultas.Columns["IdPrestamo"].HeaderText = "PRESTAMO";
            dgvMultas.Columns["DiasRetraso"].HeaderText = "Días Retraso";
            dgvMultas.Columns["NombreUsuario"].HeaderText = "Usuario";
            dgvMultas.Columns["TituloLibro"].HeaderText = "Libro";
            dgvMultas.Columns["FechaDevolucionReal"].HeaderText = "Fecha Devolucion";
            dgvMultas.Columns["FechaPago"].HeaderText = "Fecha Pago";
            dgvMultas.Columns["FechaCreacion"].HeaderText = "Creacion";

            // Oculto columnas de detalle extensivo

            dgvMultas.Columns["TarifaDiaria"].Visible = false;
            dgvMultas.Columns["MontoTotal"].Visible = false;
            dgvMultas.Columns["Estado"].Visible = false;
            dgvMultas.Columns["DocumentoIdentidad"].Visible = false;
            dgvMultas.Columns["TipoUsuario"].Visible = false;
            dgvMultas.Columns["ISBN"].Visible = false;
            dgvMultas.Columns["FechaPrestamo"].Visible = false;
            dgvMultas.Columns["FechaLimite"].Visible = false;
        }

        // 3. Cuando el usuario selecciona una fila, muestro el detalle en el panel
        private void dgvMultas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMultas.SelectedRows.Count == 0) return;

            var row = dgvMultas.SelectedRows[0];
            var detalle = row.DataBoundItem as MultaDetalle;
            if (detalle != null)
                MostrarDetalleMulta(detalle);
        }

        private void MostrarDetalleMulta(MultaDetalle m)
        {
            pnlMultaDetalle.Controls.Clear();
            int y = 10;
            const int twentyFive = 25;

            void AgregarLabel(string texto, bool negrita = false, Color? color = null)
            {
                var lbl = new Label
                {
                    Text = texto,
                    AutoSize = true,
                    Font = negrita
                        ? new Font("Segoe UI", 9, FontStyle.Bold)
                        : new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = color ?? Color.Black,
                    Location = new Point(10, y)
                };
                pnlMultaDetalle.Controls.Add(lbl);
                y += twentyFive;
            }

            // Usuario
            AgregarLabel($"👤 Usuario: {m.NombreUsuario}");
            AgregarLabel($"📄 Documento: {m.DocumentoIdentidad}");
            AgregarLabel($"🏷 Tipo: {m.TipoUsuario}");
            AgregarLabel(string.Empty);

            // Libro
            AgregarLabel($"📘 Libro: {m.TituloLibro}");
            AgregarLabel($"🔖 ISBN: {m.ISBN}");
            AgregarLabel(string.Empty);

            // Fechas
            AgregarLabel($"🗓 Préstamo: {m.FechaPrestamo:dd/MM/yyyy}");
            AgregarLabel($"📆 Límite: {m.FechaLimite:dd/MM/yyyy}");
            string real = m.FechaDevolucionReal?.ToString("dd/MM/yyyy") ?? "Pendiente";
            AgregarLabel($"✅ Devolución: {real}");
            AgregarLabel($"⏳ Días de retraso: {m.DiasRetraso}");
            AgregarLabel(string.Empty);

            // Multa
            AgregarLabel($"💸 Tarifa diaria: {m.TarifaDiaria:C}", false);
            AgregarLabel($"💵 Monto total: {m.MontoTotal:C}", false);
            AgregarLabel(string.Empty);

            // Estado con color
            bool pagada = m.Estado.Equals("Pagada", StringComparison.OrdinalIgnoreCase);
            AgregarLabel(
                $"📌 Estado: {m.Estado}",
                true,
                pagada ? Color.ForestGreen : Color.IndianRed
            );

            MessageBox.Show($"Monto Total: {m.MontoTotal}");

            // Si la multa está pagada, agregar botón al final
            if (pagada)
            {
                var btnFactura = new Button
                {
                    Text = "Generar Factura",
                    Location = new Point(10, y + 10),
                    AutoSize = true
                };
                btnFactura.Click += (s, e) => GenerarFacturaDesdeDetalle(m);
                pnlMultaDetalle.Controls.Add(btnFactura);
            }
        }

        // Método auxiliar para generar factura desde el detalle mostrado
        private void GenerarFacturaDesdeDetalle(MultaDetalle detalle)
        {
            // Si tienes el monto pagado, actualízalo aquí
            // Por ejemplo, si guardas el monto pagado en una variable o lo recuperas de la base de datos:
            decimal montoPagado = detalle.MontoTotal; // O el valor real pagado

            // Actualiza el objeto antes de generar la factura
            detalle.MontoTotal = montoPagado;

            var facturaService = new FacturaService();
            string ruta = facturaService.GenerarFacturaMulta(detalle);
            MessageBox.Show($"Factura generada en: {ruta}");
            Process.Start("explorer", ruta);
        }

        // 4. Botón “Abonar” (marcar como pagada)
        private void btnAbonar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdMulta.Text, out int id) &&
                decimal.TryParse(txtMonto.Text, out decimal monto))
            {
                bool ok = _multaController.MarcarComoPagada(id, monto, DateTime.Now);
                if (ok)
                {
                    MessageBox.Show("Multa abonada correctamente.");
                    CargarMultas();
                    txtIdMulta.Clear();
                    txtMonto.Clear();
                }
                else
                {
                    MessageBox.Show("Error al abonar la multa.");
                }
            }
            else
            {
                MessageBox.Show("ID o Monto inválido.");
            }
        }

        // 5. Botón “Eliminar Multa”
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMultas.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(dgvMultas.SelectedRows[0].Cells["IdMulta"].Value);
                var resp = MessageBox.Show(
                    "¿Confirmas eliminar esta multa?",
                    "Eliminar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (resp == DialogResult.Yes)
                {
                    bool ok = _multaController.EliminarMulta(id);
                    if (ok) CargarMultas();
                }
            }
        }

        // 6. Botón “Editar Multa”
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMultas.SelectedRows.Count > 0)
                {
                    var id = Convert.ToInt32(dgvMultas.SelectedRows[0].Cells["IdMulta"].Value);
                    var multaEditada = new Multa
                    {
                        Id = id,
                        IdPrestamo = Convert.ToInt32(dgvMultas.SelectedRows[0].Cells["IdPrestamo"].Value),
                        DiasRetraso = Convert.ToInt32(dgvMultas.SelectedRows[0].Cells["DiasRetraso"].Value),
                        TarifaDiaria = Convert.ToInt32(dgvMultas.SelectedRows[0].Cells["TarifaDiaria"].Value),
                        MontoTotal = Convert.ToInt32(dgvMultas.SelectedRows[0].Cells["MontoTotal"].Value),
                        Estado = dgvMultas.SelectedRows[0].Cells["Estado"].Value.ToString(),
                        FechaPago = (DateTime)(DateTime.TryParse(dgvMultas.SelectedRows[0].Cells["FechaPago"].Value.ToString(), out DateTime fechaPago) ? fechaPago : (DateTime?)null),
                        FechaCreacion = Convert.ToDateTime(dgvMultas.SelectedRows[0].Cells["FechaCreacion"].Value)
                    };

                    if (_multaController.EditarMulta(multaEditada))
                    {
                        MessageBox.Show("Multa Editda");
                        CargarMultas();
                    }
                    else
                    {
                        MessageBox.Show("Error al Editar la Multa");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila para editar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar la multa: {ex.Message}");
            }
        }




        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y teclas de control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.Show();
            this.Hide();
        }


        private void btnExportar_Click(object sender, EventArgs e)
        {
            var multas = _multaController.ObtenerTodas(); 
            ExportarMultasACsv(multas);
        }
        public bool ExportarMultasACsv(List<MultaDetalle> multas)
        {
            if (multas == null || multas.Count == 0)
            {
                MessageBox.Show("No hay multas para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Title = "Guardar archivo de multas",
                Filter = "CSV Files (.csv)|.csv",
                FileName = $"Multas_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return false;

            string rutaArchivo = saveFileDialog.FileName;

            try
            {
                using (var writer = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
                {
                    // Encabezado (usa el mismo separador que los datos)
                    writer.WriteLine("ID Multa;Nombre Usuario;Documento;Tipo Usuario;Libro;ISBN;Fecha Préstamo;Fecha Límite;Fecha Devolución;Días Retraso;Tarifa Diaria;Monto Total;Estado;Fecha Pago;Fecha Creación");

                    foreach (var multa in multas)
                    {
                        string[] campos = new string[]
                        {
                            multa.IdMulta.ToString(),
                            multa.NombreUsuario,
                            multa.DocumentoIdentidad,
                            multa.TipoUsuario,
                            multa.TituloLibro,
                            multa.ISBN,
                            multa.FechaPrestamo.ToString("dd/MM/yyyy"),
                            multa.FechaLimite.ToString("dd/MM/yyyy"),
                            multa.FechaDevolucionReal?.ToString("dd/MM/yyyy") ?? "Pendiente",
                            multa.DiasRetraso.ToString(),
                            multa.TarifaDiaria.ToString("F2"),
                            multa.MontoTotal.ToString("F2"),
                            multa.Estado,
                            multa.FechaPago?.ToString("dd/MM/yyyy") ?? "",
                            multa.FechaCreacion.ToString("dd/MM/yyyy")
                        };

                        writer.WriteLine(string.Join(";", campos));
                    }
                }

                MessageBox.Show($"Archivo guardado exitosamente en:\n{rutaArchivo}", "Exportación completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar el archivo:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string Escape(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "";
            texto = texto.Replace("\"", "\"\"");
            return $"\"{texto}\"";
        }


    }
}
