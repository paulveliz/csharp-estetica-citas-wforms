using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estetica_lupita.Reportes.ReportModels
{
    class VentaReporteModel
    {
        public int Id { get; set; }
        public int Cita { get; set; }
        public string Cliente { get; set; }
        public string Empleado { get; set; }
        public decimal Total { get; set; }
        public int Estatus { get; set; }
    }
}
