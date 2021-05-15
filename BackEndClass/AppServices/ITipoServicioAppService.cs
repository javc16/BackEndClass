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
        Task<Response> PostTipoUsuario(TipoServicio tipoUsuario);
        Task<Response> PutTipoUsuario(TipoServicio tipoUsuario);
        Task<Response> DeleteTipoUsuario(int id);
    }
}
