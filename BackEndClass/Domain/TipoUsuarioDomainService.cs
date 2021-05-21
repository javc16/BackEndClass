using BackEndClass.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class TipoUsuarioDomainService
    {
        public string ValidarDescripcion(string descripcion) 
        {
            if (string.IsNullOrEmpty(descripcion)) 
            {
                return Constantes.CampoObligatorio;
            }

            return Constantes.ValidacionConExito;
        }
      
    }
}
