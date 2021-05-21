using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models
{
    public class Recomendacion
    {
        public int Id { get; set; }
        public int Puntos { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdProveedor { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
