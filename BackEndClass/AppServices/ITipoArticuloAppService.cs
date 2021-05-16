using BackEndClass.Helpers;
using BackEndClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices
{
    public interface ITipoArticuloAppService
    {
        IEnumerable<TipoArticulo> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostTipoArticulo(TipoArticulo tipoArticulo);
        Task<Response> PutTipoArticulo(TipoArticulo tipoArticulo);
        Task<Response> DeleteTipoArticulo(int id);
    }
}
