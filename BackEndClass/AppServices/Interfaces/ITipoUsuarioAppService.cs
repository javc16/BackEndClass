using BackEndClass.Helpers;
using BackEndClass.Models;
using BackEndClass.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices.Interfaces
{
    public interface ITipoUsuarioAppService
    {
        IEnumerable<TipoUsuarioDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostTipoUsuario(TipoUsuario tipoUsuario);
        Task<Response> PutTipoUsuario(TipoUsuario tipoUsuario);
        Task<Response> DeleteTipoUsuario(int id);
    }
}
