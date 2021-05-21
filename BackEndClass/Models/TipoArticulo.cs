using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models
{
    public class TipoArticulo
    {
        public int id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public int Estado { get; set; }
        List<Articulo> Articulos { get; set; }

        public sealed class Builder
        {
            private readonly TipoArticulo _tipoArticulo;

            public Builder(string descripcion, string tipo)
            {
                _tipoArticulo = new TipoArticulo
                {
                    Descripcion = descripcion,
                    Tipo = tipo
                };
            }

            public Builder conEstado(int estado)
            {
                _tipoArticulo.Estado = estado;
                return this;
            }

            public TipoArticulo Construir()
            {
                return _tipoArticulo;
            }
        }
    }
}
