using BackEndClass.Helpers;
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
                return Constantes.CampoObligatorio;
            }

            return Constantes.ValidacionConExito;
        }

        public string ValidarAlias(string alias)
        {
            if (string.IsNullOrEmpty(alias))
            {
                return Constantes.CampoObligatorio;
            }

            return Constantes.ValidacionConExito;
        }

        public string ValidarPrecio(decimal precio)
        {
            if (precio==0)
            {
                return Constantes.CampoObligatorio;
            }

            return Constantes.ValidacionConExito;
        }     

        public string ValidarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return Constantes.CampoObligatorio;
            }

            return Constantes.ValidacionConExito;
        }
    }
}
