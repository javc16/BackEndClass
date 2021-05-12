using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class ArticuloDomainService
    {
        public string ValidateFirstName(string Descripcion)
        {
            if (String.IsNullOrEmpty(Descripcion))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidateLastName(string Alias)
        {
            if (string.IsNullOrEmpty(Alias))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidatePhone(string Nombre)
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidateBussines(decimal Precio)
        {
            if (Precio==0)
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }
    }
}