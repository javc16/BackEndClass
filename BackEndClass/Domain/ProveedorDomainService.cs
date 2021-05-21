using BackEndClass.Helpers;
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
                return Constantes.CampoObligatorio;
            }
                return Constantes.ValidacionConExito;
        }

        public string ValidarApellido(string apellido)
        {
            if (string.IsNullOrEmpty(apellido))
            {
                return Constantes.CampoObligatorio;
            }
                return Constantes.ValidacionConExito;
        }

        public string ValidarTelefono(string telefono)
        {
            if (string.IsNullOrEmpty(telefono))
            {
                return Constantes.CampoObligatorio;
            }
                return Constantes.ValidacionConExito;
        }

        public string ValidarEmpresa(string empresa)
        {
            if (string.IsNullOrEmpty(empresa))
            {
                return Constantes.CampoObligatorio;
            }
                return Constantes.ValidacionConExito;
        }
    }
}