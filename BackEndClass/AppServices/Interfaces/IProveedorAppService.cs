using BackEndClass.Helpers;
using BackEndClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndClass.Models.DTOs;

namespace BackEndClass.AppServices.Interfaces
{
    public interface IProveedorAppService
    {
        IEnumerable<ProveedorDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostProveedor(Proveedor proveedor);
        Task<Response> PutProveedor(Proveedor proveedor);
        Task<Response> DeleteProveedor(int id);
    }
}
