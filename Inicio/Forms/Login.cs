using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using LoginV1.Models;
using LoginV1.Controller;
using LoginV1.Forms;

namespace Inicio
{
    public partial class frmLogin : Form
    {
        private UsuarioController _usuarioController;
        public frmLogin()
        {
            InitializeComponent();
            _usuarioController = new UsuarioController();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            Usuario usuario = _usuarioController.Login(username, password);

            if (usuario != null)
            {
                MessageBox.Show($"Bienvenido, {usuario.NombreCompleto}!", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMenu menu = new frmMenu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas o usuario inactivo.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
