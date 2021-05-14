using BackEndClass.Helpers;
using BackEndClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices
{
    public interface ITipoProveedorAppService
    {
        IEnumerable<TipoProveedor> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostTipoProveedor(TipoProveedor tipoProveedor);
        Task<Response> PutTipoProveedor(TipoProveedor tipoProveedor);
        Task<Response> DeleteTipoProveedor(int id);
    }
}