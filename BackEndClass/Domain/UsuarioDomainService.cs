using BackEndClass.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class UsuarioDomainService
    {
        public string ValidarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return Constantes.CampoObligatorio + "nombre";
            }

            return Constantes.ValidacionConExito;
        }

        public string ValidarApellido(string apellido)
        {
            if (string.IsNullOrEmpty(apellido))
            {
                return Constantes.CampoObligatorio + "apellido";
            }

            return Constantes.ValidacionConExito;
        }
    }
}
