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
    public partial class HomePage : Form
    {
        public HomePage( string _user, string _email, string _pass)
        {
            InitializeComponent();
            lblBienvenido.Text = $"Bienvenido {_user} \n Correo: {_email} \n Contraseña: {_pass}" ;
        }
    }
}
