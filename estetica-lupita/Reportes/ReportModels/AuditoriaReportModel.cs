using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estetica_lupita.Reportes.ReportModels
{
    class AuditoriaReportModel
    {
        public int idauditoria { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fecha { get; set; }
        public System.TimeSpan hora { get; set; }
        public string usuario { get; set; }
    }
}
