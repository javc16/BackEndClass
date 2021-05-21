using BackEndClass.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class ArticuloDomainService
    {
        public string ValidarNombre(string Nombre)
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                return Constantes.CampoObligatorio;
            }

            return Constantes.ValidacionConExito;
        }

        public string ValidarDescripcion(string Descripcion)
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                return Constantes.CampoObligatorio;
            }

            return Constantes.ValidacionConExito;
        }
        public string ValidarAlias(string Alias)
        {
            if (string.IsNullOrEmpty(Alias))
            {
                return Constantes.CampoObligatorio;
            }

            return Constantes.ValidacionConExito;
        }

        public string ValidarPrecio(string precio)
        {
            if (string.IsNullOrEmpty(precio))
            {
                return Constantes.CampoObligatorio;
            }

            return Constantes.ValidacionConExito;
        }

        public string ValidarBussines(decimal Precio)
        {
            if (Precio==0)
            {
                return Constantes.CampoObligatorio;
            }

            return Constantes.ValidacionConExito;
        }
    }
}