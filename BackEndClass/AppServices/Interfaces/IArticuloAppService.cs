using BackEndClass.Helpers;
using BackEndClass.Models;
using BackEndClass.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BackEndClass.AppServices.Interfaces
{
    public interface IArticuloAppService
    {
        IEnumerable<ArticuloDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostArticulo(ArticuloDTO articulo);
        Task<Response> PutArticulo(ArticuloDTO articulo);
        Task<Response> DeleteArticulo(ArticuloDTO articulo);

        
    }
}