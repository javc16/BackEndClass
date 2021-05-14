using BackEndClass.Helpers;
using BackEndClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices
{
    interface IProveedorAppService
    {
        IEnumerable<Proveedor> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostProveedor(Proveedor proveedor);
        Task<Response> PutProveedor(Proveedor proveedor);
        Task<Response> DeleteProveedor(int id);
    }
}
