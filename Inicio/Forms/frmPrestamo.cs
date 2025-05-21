using LoginV1.Controller;
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var prestamos = prestamoController.ObtenerPrestamos();
            dtgPrestamos.DataSource = null; // Limpiar el DataGridView
            dtgPrestamos.DataSource = prestamos; // Asignar la lista de préstamos como fuente de datos
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
                    btnActualizar_Click(sender, e); // Actualizar la lista de préstamos
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

        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.Show();
            this.Hide();
        }
    }
}
