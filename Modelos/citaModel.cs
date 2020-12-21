using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class citaModel
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int Estatus { get; set; }
    }
}
