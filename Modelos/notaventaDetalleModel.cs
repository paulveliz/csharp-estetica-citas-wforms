﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class notaventaDetalleModel
    {
        public int Id { get; set; }
        public string Servicio { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
