using BackEndClass.Context;
using BackEndClass.Domain;
using BackEndClass.Helpers;
using BackEndClass.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndClass.Models.DTOs;
using BackEndClass.AppServices.Interfaces;

namespace BackEndClass.AppServices
{
    public class ProveedorAppService : IProveedorAppService
    {
        private readonly MWSContext _context;
        private readonly ProveedorDomainService _proveedorDomainService;

        public ProveedorAppService(MWSContext context, ProveedorDomainService proveedorDomainService)
        {
            _context = context;
            _proveedorDomainService = proveedorDomainService;
        }

        public IEnumerable<ProveedorDTO> GetAll()
        {
            var proveedores = _context.Proveedor.Where(x => x.Estado==Constantes.Activo);
            var proveedoresDTO = ProveedorDTO.DeModeloADTO(proveedores);
            return proveedoresDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var proveedor = await _context.Proveedor.FirstOrDefaultAsync(r => r.Id == id);
            if (proveedor == null)
            {
                return new Response { Mensaje = "Este Proveedor no existe" };
            }

            var data = ProveedorDTO.DeModeloADTO(proveedor);
            return new Response { Datos = data };
        }

        public async Task<Response> PostProveedor(ProveedorDTO proveedorDTO)
        {
            string mensaje = _proveedorDomainService.ValidarNombre(proveedorDTO.Nombre);
            if (!mensaje.Equals(Constantes.ValidacionConExito))
            {
                return new Response { Mensaje = mensaje };
            }

            var GuardarProveedor= await _context.Proveedor.FirstOrDefaultAsync(r => r.Nombre == proveedorDTO.Nombre);
            if (GuardarProveedor != null && GuardarProveedor.Estado == Constantes.Activo)
            {
                return new Response { Mensaje = "Este proveedor ya existe en el sistema" };
            }
            else if ((GuardarProveedor != null && GuardarProveedor.Estado == Constantes.Inactivo)) 
            {
                GuardarProveedor.Estado = Constantes.Activo;
                GuardarProveedor.Image = proveedorDTO.Image;
                _context.Entry(GuardarProveedor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new Response { Mensaje = $"Proveedor {GuardarProveedor.Nombre} activado correctamente" };
            }
            var proveedor = ProveedorDTO.DeDTOAModelo(proveedorDTO);
            _context.Proveedor.Add(proveedor);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Proveedor agregado correctamente" };
        }

        public async Task<Response> PutProveedor(ProveedorDTO proveedorDTO)
        {
            var proveedor = ProveedorDTO.DeDTOAModelo(proveedorDTO);

            _context.Entry(proveedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Proveedor {proveedor.Nombre} modificado correctamente" };
        }

        public async Task<Response> DeleteProveedor(ProveedorDTO proveedorDTO)
        {
            var proveedor = await _context.Proveedor.FindAsync(proveedorDTO.Id);
            if (proveedor == null)
            {
                return new Response { Mensaje = $"No tenemos un proveedor con ese id" }; ;
            }
            proveedor.Estado = Constantes.Inactivo;
            _context.Entry(proveedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Proveedor {proveedor.Nombre} eliminado correctamente" };
        }

    }
}

