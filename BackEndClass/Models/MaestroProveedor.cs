using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models
{
    public class MaestroProveedor
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        List<Proveedor> Proveedores { get; set; }
        List<Articulo> Articulos { get; set; }
        List<Servicio> Servicios { get; set; }


    }
}
