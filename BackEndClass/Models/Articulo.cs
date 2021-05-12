using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BackEndClass.Models
{
  
        public class Articulo
        {
             public int Id { get; set; }
            public string Description { get; set; }
            public string Alias { get; set; }
            public string ArticleTypeID { get; set; }
            public int Price { get; set; }
            public bool status { get; set; }
            public string Name { get; set; }
         }
}