using BackEndClass.Helpers;
using BackEndClass.Models;
using BackEndClass.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices.Interfaces
{
    public interface ITipoServicioAppService
    {
        IEnumerable<TipoServicioDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostTipoServicio(TipoServicioDTO tipoServicio);
        Task<Response> PutTipoServicio(TipoServicioDTO tipoServicio);
        Task<Response> DeleteTipoServicio(TipoServicioDTO tipoServicio);
    }
}
