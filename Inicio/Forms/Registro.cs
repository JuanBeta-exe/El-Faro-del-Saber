using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inicio
{
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void Btn_Registrar_Click(object sender, EventArgs e)
        {

        }

        private bool Validar_Campos()
        {
            if (txt_Nombre.Text == "" || txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return false;
            }
            else { return true; }
        }

        private void press_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_Registrar_Click(sender, e);
            }
        }
    }
}
