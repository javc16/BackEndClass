using BackEndClass.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class TipoServicioDomainService
    {
        public string ValidarDescripcion(string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
            {
                return Constantes.CampoObligatorio;
            }

            return Constantes.ValidacionConExito;
        }

        public string ValidarTipo(string tipo)
        {
            if (string.IsNullOrEmpty(tipo))
            {
                return Constantes.CampoObligatorio;
            }

            return Constantes.ValidacionConExito;
        }

    }
}
