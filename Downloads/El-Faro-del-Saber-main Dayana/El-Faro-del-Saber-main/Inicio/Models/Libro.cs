using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginV1.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string ISBN { get; set; }
        public int AñoPublicacion { get; set; }
        public int Categoria { get; set; }
        public int Cantidad { get; set; }
        public int EjemplaresDisponibles { get; set; }
        public string Estado { get; set; }
    }
}
