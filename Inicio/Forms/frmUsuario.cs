using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginV1.Models;
using LoginV1.Controller;
using System.Drawing.Printing;
using LoginV1.Forms;

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
            cbxTipoUsuario.KeyPress += NoEscribir_KeyPress;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConsulta.Text))
            {
                CargarUsuarios();
            }
            else
            {
                var usuarios = _usuarioController.ObtenerUsuarios(txtConsulta.Text);
                dgvUsuarios.DataSource = null; // Limpiar la fuente de datos antes de asignar una nueva
                dgvUsuarios.DataSource = usuarios;
            }
            txtConsulta.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposAgregar())
                {
                    var nuevoUsuario = new Usuario
                    {
                        NombreCompleto = txtNombre.Text,
                        DocumentoIdentidad = txtDocumento.Text,
                        Correo = txtCorreo.Text,
                        Telefono = txtTelefono.Text,
                        Direccion = txtDireccion.Text,
                        TipoUsuario = cbxTipoUsuario.SelectedItem.ToString(),
                        Username = txtUsername.Text,
                        Password = txtPassword.Text
                    };
                    _usuarioController.AgregarUsuario(nuevoUsuario);
                    CargarUsuarios();
                    limpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar el usuario:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    // Obtener el ID del usuario seleccionado
                    int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[0].Value);

                    // Crear un objeto Usuario con los datos editados
                    var usuarioEditado = new Usuario
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
                        Estado = dgvUsuarios.SelectedRows[0].Cells[9].Value.ToString()
                    };
                    // Llamar al método para actualizar el usuario
                    _usuarioController.EditarUsuario(usuarioEditado);
                    CargarUsuarios();
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar el usuario:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    // Obtener el ID del usuario seleccionado
                    int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[0].Value);
                    // Llamar al método para eliminar el usuario
                    if (_usuarioController.EliminarUsuario(id))
                    {
                        MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al eliminar el usuario:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuarios()
        {
            var usuarios = _usuarioController.ObtenerUsuarios();
            dgvUsuarios.DataSource = null; // Limpiar la fuente de datos antes de asignar una nueva
            dgvUsuarios.DataSource = usuarios;
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

        private void NoEscribir_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No permite escribir en el campo
            e.Handled = true;
        }
        private bool ValidarCamposAgregar()
        {
            // Lista de campos y sus nombres amigables
            var campos = new List<(Control, string)>
            {
                (txtNombre, "Nombre Completo"),
                (txtDocumento, "Documento Identidad"),
                (txtCorreo, "Correo"),
                (txtTelefono, "Telefono"),
                (txtDireccion, "Direccion"),
                (cbxTipoUsuario, "Tipo Usuario"),
                (txtUsername, "Username"),
                (txtPassword, "Contraseña")
            };

            var camposFaltantes = new List<string>();

            // Restablece el color de fondo de todos los TextBox
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

        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtDocumento.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            cbxTipoUsuario.SelectedIndex = -1;
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.Show();
            this.Hide();
        }
    }
}
    
    
    


