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
        Task<Response> PostTipoServicio(TipoServicio tipoServicio);
        Task<Response> PutTipoServicio(TipoServicio tipoServicio);
        Task<Response> DeleteTipoServicio(int id);
    }
}
