﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.ModelsMineria
{
    public class PromediosLugarExplotacionOR
    {
        public string tipo_plantilla { get; set; }
        public string municipio { get; set; }
        public string dato { get; set; }
        public int cantidad { get; set; }
        public double porcentaje { get; set; }
    }
}
