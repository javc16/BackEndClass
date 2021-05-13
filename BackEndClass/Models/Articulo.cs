using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BackEndClass.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Alias { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }
    }
}