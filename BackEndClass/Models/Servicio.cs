using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models
{
    public class Servicio
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Alias { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }
    }
}