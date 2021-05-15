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
        Task<Response> PostTipoUsuario(TipoArticulo tipoArticulo);
        Task<Response> PutTipoUsuario(TipoArticulo tipoArticulo);
        Task<Response> DeleteTipoUsuario(int id);
    }
}
