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
                // 1. Validar campos  
                if (!int.TryParse(txtIdUsuario.Text.Trim(), out int idUsuario))
                {
                    MessageBox.Show("ID de usuario inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpkFechaEstipulada.Value.Day >= 0)
                {
                    // 2. Crear instancia del controlador una sola vez  
                    var controller = new PrestamoController();

                    // 3. Preparar objeto Prestamo  
                    var prestamo = new Models.Prestamo
                    {
                        IdUsuario = idUsuario,
                        FechaPrestamo = DateTime.Now,
                        FechaEstimada = dtpkFechaEstipulada.Value,
                        Estado = "Activo"  // Asumiendo que "Activo" es el valor correcto en tu DB  
                    };

                    // 4. Ejecutar la acción correspondiente  
                    bool resultado;
                    switch (accion)
                    {
                        case "Agregar":
                            resultado = controller.AgregarPrestamo(prestamo, /* aquí la lista de IDs de libros */ new List<int> { /* idLibro */ });
                            break;

                        case "Extender":
                            // Para extender, asumimos que prestamo.Id ya contiene el id del préstamo existente  
                            resultado = controller.ActualizarPrestamo(prestamo);
                            break;

                        default:
                            MessageBox.Show("Acción desconocida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                    }

                    // 5. Notificar al usuario y refrescar la grilla  
                    if (resultado)
                    {
                        MessageBox.Show("Operación realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al procesar la solicitud.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Número de días inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo una excepción: {ex.Message}", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
