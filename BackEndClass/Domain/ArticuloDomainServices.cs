using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class ArticuloDomainService
    {
        public string ValidateFirstName(string Descripción)
        {
            if (String.IsNullOrEmpty(Descripción))
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

        public string ValidatePhone(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public int ValidateBussines(string Price)
        {
            if (Int.IsNullOrEmpty(Price))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }
    }
}