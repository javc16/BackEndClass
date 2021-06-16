using BackEndClass.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndClass.Models.DTOs;

namespace BackEndClass.AppServices.Interfaces
{
    public interface IProveedorAppService
    {
        IEnumerable<ProveedorDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostProveedor(ProveedorDTO proveedor);
        Task<Response> PutProveedor(ProveedorDTO proveedor);
        Task<Response> DeleteProveedor(ProveedorDTO proveedor);
    }
}
