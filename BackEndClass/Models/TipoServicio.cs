using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models
{
    public class TipoServicio
    {
        public int id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public int Estado { get; set; }
        List<Servicio> Servicios { get; set; }

        public sealed class Builder
        {
            private readonly TipoServicio _tipoServicio;

            public Builder(string descripcion, string tipo)
            {
                _tipoServicio = new TipoServicio
                {
                    Descripcion = descripcion,
                    Tipo = tipo
                };
            }

            public Builder conEstado(int estado)
            {
                _tipoServicio.Estado = estado;
                return this;
            }

            public TipoServicio Construir()
            {
                return _tipoServicio;
            }
        }
    }
}
