using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginV1.Controller;
using LoginV1.DataAccess;

namespace LoginV1.Forms
{
    public partial class frmAccionPrestamo : Form
    {
        private string accion;
        public frmAccionPrestamo(string accion)
        {
            InitializeComponent();
            this.accion = accion;

            if (accion == "Extender")
            {
                lblTitulo.Text = "Extender Prestamo";
                lblIdUusario.Text = "Ingrese el nuevo plazo del prestamo:";
                btnAceptar.Text = "Extender";
                lblIdLibro.Visible = false;
                lblIdLibro.Enabled = false;
                txtIdLibro.Visible = false;
                txtIdLibro.Enabled = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = SQLiteConnectionManager.GetConnection())
                {
                    connection.Open();
                    if (accion == "Agregar")
                    {
                        PrestamoController prestamoController = new PrestamoController();
                        prestamoController.RegistrarPrestamo(new Models.Prestamo
                        {
                            IdUsuario = Convert.ToInt32(txtIdUsuario.Text),
                            FechaInicio = DateTime.Now,
                            FechaFin = DateTime.Now.AddDays(Convert.ToInt32(txtIdLibro.Text)),
                            Estado = 1
                        });
                    }
                    else if (accion == "Extender")
                    {
                        PrestamoController prestamoController = new PrestamoController();
                        prestamoController.ActualizarPrestamo(new Models.Prestamo
                        {
                            Id = Convert.ToInt32(txtIdUsuario.Text),
                            FechaFin = DateTime.Now.AddDays(Convert.ToInt32(txtIdLibro.Text)),
                            Estado = 1
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }
    }
}
