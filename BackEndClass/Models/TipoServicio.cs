using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models
{
    public class TipoServicio
    {
        public int id { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public bool status { get; set; }
    }
}
