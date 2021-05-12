using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models
{
    public class Servicio
    {
        public int id { get; set; }
        public string description { get; set; }
        public string alias { get; set; }
        public int TipoServiciosID { get; set; }
        public int price { get; set; }
        public string status { get; set; }
        public string name { get; set; }
    }
}