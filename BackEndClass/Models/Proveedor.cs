using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Empresa { get; set; }
        public string Direccion { get; set; }
        public int Estado { get; set; }
        public string Image { get; set; }
        List<Recomendacion> Recomendaciones { get; set; }
        public int IdMestroProveedor { get; set; }
        public MaestroProveedor MaestroProveedor { get; set; }
        public sealed class Builder
        {
            private readonly Proveedor _proveedor;

            public Builder(string nombre, string apellido, string email, string telefono,
                            string empresa, string direccion, string image)
            {
                _proveedor = new Proveedor
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Email = email,
                    Telefono = telefono,
                    Empresa = empresa,
                    Direccion = direccion,
                    Image = image
                };
            }
            public Builder conEstado(int estado)
            {
                _proveedor.Estado = estado;
                return this;
            }

            public Proveedor Construir()
            {
                return _proveedor;
            }
        }
    }
}