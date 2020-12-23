using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estetica_lupita.Reportes.ReportModels
{
    class TicketCitaModel
    {
        public int Id { get; set; }
        public int ServicioId { get; set; }
        public string Servicio { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
    }
}
