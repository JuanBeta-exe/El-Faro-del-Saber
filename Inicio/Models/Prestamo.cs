using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginV1.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }         // Relación con Usuarios
        public int IdLibro { get; set; }           // Relación con Libros
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Estado { get; set; }         // Por ejemplo: "Activo", "Devuelto", "Vencido"
    }
}
