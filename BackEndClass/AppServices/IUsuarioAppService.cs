using BackEndClass.Helpers;
using BackEndClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices
{
    interface IUsuarioAppService
    {
        IEnumerable<Usuario> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostUsuario(Usuario usuario);
        Task<Response> PutUsuario(Usuario usuario);
        Task<Response> DeleteUsuario(int id);
    }
}
