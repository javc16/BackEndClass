﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models.DTOs
{
    public class TipoArticuloDTO
    {
        public int id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public int Estado { get; set; }
    }
}
