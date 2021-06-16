using BackEndClass.Helpers;
using BackEndClass.Models;
using BackEndClass.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices.Interfaces
{
    public interface ITipoArticuloAppService
    {
        IEnumerable<TipoArticuloDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostTipoArticulo(TipoArticuloDTO tipoArticulo);
        Task<Response> PutTipoArticulo(TipoArticuloDTO tipoArticulo);
        Task<Response> DeleteTipoArticulo(TipoArticuloDTO tipoArticulo);
    }
}
