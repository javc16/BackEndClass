using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class UserTypeDomainService
    {
        public string ValidateDescription(string descripcion) 
        {
            if (string.IsNullOrEmpty(descripcion)) 
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }
    }
}
