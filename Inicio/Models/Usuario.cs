using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginV1.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TipoUsuario { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
    }
}
