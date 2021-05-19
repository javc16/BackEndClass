using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models
{
    public class TipoUsuario
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public sealed class Builder 
        {
            private readonly TipoUsuario _tipoUsuario;

            public Builder(string descripcion) 
            {
                _tipoUsuario = new TipoUsuario
                {
                    Descripcion = descripcion
                };   
            }

            public Builder conEstado(int estado) 
            {
                _tipoUsuario.Estado = estado;
                return this;
            }

            public TipoUsuario Constuir() 
            {
                return _tipoUsuario;
            }
        }
    }
}
