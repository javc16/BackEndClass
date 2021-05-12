using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BackEndClass.Models
{
  
        public class Articulo
        {
             public int Id { get; set; }
            public string descripcion { get; set; }
            public string Alias { get; set; }
            public string ArticleTypeID { get; set; }
            public string Precio { get; set; }
            public bool status { get; set; }
            public string Nombre { get; set; }
         }
}