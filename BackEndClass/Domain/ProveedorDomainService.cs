using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class ProveedorDomainService
    {
        public string ValidarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return "El campo no puede estar vacio";
            }
                return "El campo fue validado con exito";
        }

        public string ValidarApellido(string apellido)
        {
            if (string.IsNullOrEmpty(apellido))
            {
                return "El campo no puede estar vacio";
            }
                return "El campo fue validado con exito";
        }

        public string ValidarTelefono(string telefono)
        {
            if (string.IsNullOrEmpty(telefono))
            {
                return "El campo no puede estar vacio";
            }
                return "El campo fue validado con exito";
        }

        public string ValidarEmpresa(string empresa)
        {
            if (string.IsNullOrEmpty(empresa))
            {
                return "El campo no puede estar vacio";
            }
                return "El campo fue validado con exito";
        }
    }
}