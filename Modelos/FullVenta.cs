using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class FullVenta
    {
        public notaventaModel NotaVenta { get; set; }
        public List<notaventaDetalleModel> NotaDetalle { get; set; }

        public FullVenta(notaventaModel nota, List<notaventaDetalleModel> detalle)
        {
            this.NotaVenta = nota;
            this.NotaDetalle = detalle;
        }
    }
}
