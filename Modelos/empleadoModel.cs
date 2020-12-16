using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class empleadoModel
    {
        public short Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public decimal Sueldo { get; set; }
        public string Puesto { get; set; }
        public int Estatus { get; set; }
    }
}
