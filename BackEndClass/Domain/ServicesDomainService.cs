using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class ServicesDomainService
    {
        public string ValidateDescription(string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidateAlias(string alias)
        {
            if (string.IsNullOrEmpty(alias))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public int ValidatePrice(int precio)
        {
            if (int.IsNullOrEmpty(precio))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidateStatus(string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidateName(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }
    }
}
