using BackEndClass.Helpers;
using BackEndClass.Models;
using BackEndClass.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices
{
    public interface ITipoServicioAppService
    {
        IEnumerable<TipoServicioDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostTipoServicio(TipoServicio tipoUsuario);
        Task<Response> PutTipoServicio(TipoServicio tipoUsuario);
        Task<Response> DeleteTipoServicio(int id);
    }
}
