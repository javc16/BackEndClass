using BackEndClass.Helpers;
using BackEndClass.Models;
using BackEndClass.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices
{
    public interface IUsuarioAppService
    {
        IEnumerable<UsuarioDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostUsuario(Usuario usuario);
        Task<Response> PutUsuario(Usuario usuario);
        Task<Response> DeleteUsuario(int id);
    }
}
