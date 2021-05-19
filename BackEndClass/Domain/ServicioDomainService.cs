using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class ServicioDomainService
    {
        public string ValidarDescripcion(string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidarAlias(string alias)
        {
            if (string.IsNullOrEmpty(alias))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidarPrecio(decimal precio)
        {
            if (precio==0)
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }     

        public string ValidarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }
    }
}
