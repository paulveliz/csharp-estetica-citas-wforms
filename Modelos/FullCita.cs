using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class FullCita
    {
        public citaModel Cita { get; set; }
        public List<citaDetalleModel> CitaDetalle { get; set; }

        public FullCita(citaModel cita, List<citaDetalleModel> citadetalle)
        {
            this.Cita = cita;
            this.CitaDetalle = citadetalle;
        }
    }
}
