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
        }

        // 1. Al cargar el formulario, traigo todas las multas
        private void frmMulta_Load(object sender, EventArgs e)
        {
            RefrescarGrilla();
        }

        // 2. Botón “Consultar” (puede recargar o aplicar filtro de texto encima)
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            RefrescarGrilla();
        }

        private void RefrescarGrilla()
        {
            // Obtiene todas las multas (desde la vista SQL)
            _listaMultas = _multaController.ObtenerTodas();
            dgvMultas.DataSource = _listaMultas;

            // Ajustes visuales básicos
            dgvMultas.Columns["IdMulta"].HeaderText = "ID";
            dgvMultas.Columns["NombreUsuario"].HeaderText = "Usuario";
            dgvMultas.Columns["TituloLibro"].HeaderText = "Libro";
            dgvMultas.Columns["MontoTotal"].HeaderText = "Monto";
            dgvMultas.Columns["Estado"].HeaderText = "Estado";
            // Oculto columnas de detalle extensivo
            dgvMultas.Columns["IdPrestamo"].Visible = false;
            dgvMultas.Columns["IdUsuario"].Visible = false;
            dgvMultas.Columns["DocumentoIdentidad"].Visible = false;
            dgvMultas.Columns["TipoUsuario"].Visible = false;
            dgvMultas.Columns["ISBN"].Visible = false;
            dgvMultas.Columns["FechaPrestamo"].Visible = false;
            dgvMultas.Columns["FechaLimite"].Visible = false;
            dgvMultas.Columns["FechaDevolucionReal"].Visible = false;
            dgvMultas.Columns["DiasRetraso"].Visible = false;
            dgvMultas.Columns["TarifaDiaria"].Visible = false;
            dgvMultas.Columns["FechaPago"].Visible = false;
            dgvMultas.Columns["FechaCreacion"].Visible = false;
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
        }

        // 4. Botón “Abonar” (marcar como pagada)
        private void btnAbonar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdMulta.Text, out int id) &&
                decimal.TryParse(txtMonto.Text, out _))
            {
                bool ok = _multaController.MarcarComoPagada(id, DateTime.Now);
                if (ok)
                {
                    MessageBox.Show("Multa abonada correctamente.");
                    RefrescarGrilla();
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
            if (int.TryParse(txtIdMulta.Text, out int id))
            {
                var resp = MessageBox.Show(
                    "¿Confirmas eliminar esta multa?",
                    "Eliminar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (resp == DialogResult.Yes)
                {
                    bool ok = _multaController.EliminarMulta(id);
                    if (ok) RefrescarGrilla();
                }
            }
        }

        // 6. Botón “Editar Multa”
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Aquí podrías abrir un diálogo para cambiar tarifa o estado manualmente
            MessageBox.Show("Funcionalidad de edición no implementada aún.");
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.Show();
            this.Hide();
        }
    }
}
