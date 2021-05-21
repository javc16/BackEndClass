using BackEndClass.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class ArticuloDomainService
    {
        public string ValidarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return Constantes.CampoObligatorio+"nombre";
            }

            return Constantes.ValidacionConExito;
        }

        public string ValidarDescripcion(string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
            {
                return Constantes.CampoObligatorio+ "descripcion";
            }

            return Constantes.ValidacionConExito;
        }
        public string ValidarAlias(string alias)
        {
            if (string.IsNullOrEmpty(alias))
            {
                return Constantes.CampoObligatorio+"alias";
            }

            return Constantes.ValidacionConExito;
        }

        public string ValidarPrecio(decimal precio)
        {
            if (precio ==0)
            {
                return Constantes.CampoObligatorio+"precio";
            }

            return Constantes.ValidacionConExito;
        }

        public string ValidarBussines(string empresa)
        {
            if (string.IsNullOrEmpty(empresa))
            {
                return Constantes.CampoObligatorio+"empresa";
            }

            return Constantes.ValidacionConExito;
        }
    }
}