using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginV1.Controller;
using LoginV1.Forms;
using LoginV1.Models;

namespace Gestion_Usuarioo
{
    public partial class FrmUsuario : Form
    {
        private UsuarioController _usuarioController = new UsuarioController();
        public FrmUsuario()
        {
            InitializeComponent();
            CargarUsuarios();

            txtNombre.KeyPress += SoloLetras_KeyPress;
            txtDocumento.KeyPress += SoloNumeros_KeyPress;
            txtTelefono.KeyPress += SoloNumeros_KeyPress;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtConsulta.Text))
            {
                CargarUsuarios();
            }
            else
            {
                var usuarios = _usuarioController.ObtenerUsuarios(txtConsulta.Text);
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = usuarios;
            }
            txtConsulta.Clear();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario
            {
                NombreCompleto = txtNombre.Text,
                DocumentoIdentidad = txtDocumento.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                TipoUsuario = cbxTipoUsuario.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Estado = "Activo",
            };
            if (ValidarCamposAgregar())
            {
                try
                {
                    _usuarioController.AgregarUsuario(usuario);
                    CargarUsuarios();
                    LimpiarCampos();
                    MessageBox.Show("Usuario agregado con éxito.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar usuario: " + ex.Message);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                // Obtener el ID del libro seleccionado
                int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[0].Value);

                // Crear un objeto Libro con los datos editados
                var UsuarioEditado = new Usuario
                {
                    Id = id,
                    NombreCompleto = dgvUsuarios.SelectedRows[0].Cells[1].Value.ToString(),
                    DocumentoIdentidad = dgvUsuarios.SelectedRows[0].Cells[2].Value.ToString(),
                    Correo = dgvUsuarios.SelectedRows[0].Cells[3].Value.ToString(),
                    Telefono = dgvUsuarios.SelectedRows[0].Cells[4].Value.ToString(),
                    Direccion = dgvUsuarios.SelectedRows[0].Cells[5].Value.ToString(),
                    TipoUsuario = dgvUsuarios.SelectedRows[0].Cells[6].Value.ToString(),
                    Username = dgvUsuarios.SelectedRows[0].Cells[7].Value.ToString(),
                    Password = dgvUsuarios.SelectedRows[0].Cells[8].Value.ToString(),
                    Estado = dgvUsuarios.SelectedRows[0].Cells[9].Value.ToString(),
                };

                // Llamar al método EditarLibro del controlador
                if (_usuarioController.ActualizarUsuario(UsuarioEditado))
                {
                    MessageBox.Show("Usuario editado con éxito.");
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al editar el Usuario.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtener el valor de la primera columna (por ejemplo, "Id") de la fila seleccionada y almacenarlo como entero
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[0].Value);
                // Llamar al método EliminarLibro del controlador
                if (_usuarioController.EliminarUsuario(id))
                {
                    MessageBox.Show("Libro eliminado con éxito.");
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el libro.");
                }
            }
        }


        private void CargarUsuarios()
        {
            var usuarios = _usuarioController.ObtenerUsuarios();
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarios;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDocumento.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            cbxTipoUsuario.Text = "SELECCIONAR";
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y teclas de control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras, espacio y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private bool ValidarCamposAgregar()
        {
            // Lista de campos y sus nombres amigables  
            var campos = new List<(Control, string)>
           {
               (txtNombre, "Nombre Completo"),
               (txtDocumento, "Documento"),
               (txtCorreo, "Correo"),
               (txtDireccion, "Dirección"),
               (txtTelefono, "Telefono"),
               (cbxTipoUsuario, "Tipo"),
               (txtUsername, "Username"),
               (txtPassword, "Contraseña")
           };

            var camposFaltantes = new List<string>();

            // Restablece el color de fondo de todos los controles  
            foreach (var campo in campos)
                campo.Item1.BackColor = Color.White;

            // Verifica cuáles están vacíos  
            foreach (var campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo.Item1.Text))
                {
                    camposFaltantes.Add(campo.Item2);
                    campo.Item1.BackColor = Color.Crimson; // Resalta el campo faltante  
                }
            }

            if (camposFaltantes.Count > 0)
            {
                MessageBox.Show(
                    "Debe completar los siguientes campos:\n- " + string.Join("\n- ", camposFaltantes),
                    "Campos obligatorios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.Show();
            this.Hide();
        }
    }
}
    
    
    


