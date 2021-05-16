using BackEndClass.Helpers;
using BackEndClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices
{
    public interface ITipoServicioAppService
    {
        IEnumerable<TipoServicio> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostTipoServicio(TipoServicio tipoUsuario);
        Task<Response> PutTipoServicio(TipoServicio tipoUsuario);
        Task<Response> DeleteTipoServicio(int id);
    }
}
