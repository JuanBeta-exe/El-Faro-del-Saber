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
        public string DocumentoIdentidad { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string TipoUsuario { get; set; } // "Administrador", "Trabajador", "Cliente"
        public string Username { get; set; }
        public string Password { get; set; } 
        public string Estado { get; set; }   
        public DateTime FechaCreacion { get; set; }
    }
}
