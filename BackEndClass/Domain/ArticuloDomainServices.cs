using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class ArticuloDomainService
    {
        public string ValidarNombre(string Nombre)
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidarDescripcion(string Descripcion)
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }
        public string ValidarAlias(string Alias)
        {
            if (string.IsNullOrEmpty(Alias))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidarPrecio(string precio)
        {
            if (string.IsNullOrEmpty(precio))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidarBussines(decimal Precio)
        {
            if (Precio==0)
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }
    }
}