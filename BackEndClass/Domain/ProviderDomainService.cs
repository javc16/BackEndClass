using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class ProviderDomainService
    {
        public string ValidateFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidateLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidatePhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidateBussines(string bussines)
        {
            if (string.IsNullOrEmpty(bussines))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }
    }
}