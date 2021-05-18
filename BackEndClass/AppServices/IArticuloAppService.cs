using BackEndClass.Helpers;
using BackEndClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BackEndClass.AppServices
{
    interface IArticuloAppService
    {
        IEnumerable<Articulo> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostArticulo(Articulo Articulo);
        Task<Response> PutArticulo(Articulo Articulo);
        Task<Response> DeleteArticuloUsuario(int id);
        
    }
}