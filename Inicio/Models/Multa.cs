using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginV1.Models
{
    public class Multa
    {
        public int Id { get; set; } // ID de la multa
        public int IdPrestamo { get; set; } // FK al préstamo
        public int DiasRetraso { get; set; } // Días de atraso
        public decimal TarifaDiaria { get; set; } // Tarifa por día de atraso
        public decimal MontoTotal { get; set; } // Monto total a pagar
        public string Estado { get; set; } // Estado de la multa (Pagada/No pagada)
        public DateTime FechaPago { get; set; }
        public DateTime FechaCreacion { get; set; } // Fecha de creación de la multa     
    }
}
