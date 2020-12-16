using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class notaventaModel
    {
        public int Id { get; set; }
        public int Cita { get; set; }
        public string Cliente { get; set; }
        public string Empleado { get; set; }
        public decimal Total { get; set; }
        public int Estatus { get; set; }
        public List<ventaDetalle> Detalle { get; set; }
    }

    public class ventaDetalle
    {
        public int Id { get; set; }
        public string Servicio { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
