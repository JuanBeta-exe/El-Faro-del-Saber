using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginV1.Models
{
    public class MultaDetalle
    {
        // Multa
        public int IdMulta { get; set; }
        public int IdPrestamo { get; set; }
        public int IdUsuario { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaPago { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Usuario
        public string NombreUsuario { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string TipoUsuario { get; set; }

        // Libro
        public string TituloLibro { get; set; }
        public string ISBN { get; set; }

        // Préstamo
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }

        // Cálculo de multa
        public int DiasRetraso { get; set; }
        public decimal TarifaDiaria { get; set; }
        public decimal MontoTotal { get; set; }
    }
}
