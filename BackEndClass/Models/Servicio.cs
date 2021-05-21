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
        public int IdTipoServicio { get; set; }
        public TipoServicio TipoServicio { get; set; }
        public sealed class Builder
        {
            private readonly Servicio _servicio;

            public Builder(string descripcion, string alias, decimal precio, string nombre)
            {
                _servicio = new Servicio
                {
                    Descripcion = descripcion,
                    Alias = alias,
                    Precio = precio,
                    Nombre = nombre
                };
            }

            public Builder conEstado(int estado)
            {
                _servicio.Estado = estado;
                return this;
            }

            public Servicio Construir()
            {
                return _servicio;
            }
        }
    }
}