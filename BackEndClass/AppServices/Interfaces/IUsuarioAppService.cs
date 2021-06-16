using BackEndClass.Helpers;
using BackEndClass.Models;
using BackEndClass.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices.Interfaces
{
    public interface IUsuarioAppService
    {
        IEnumerable<UsuarioDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostUsuario(UsuarioDTO usuario);
        Task<Response> PutUsuario(UsuarioDTO usuario);
        Task<Response> DeleteUsuario(UsuarioDTO usuario);
    }
}
