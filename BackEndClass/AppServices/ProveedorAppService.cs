using BackEndClass.Context;
using BackEndClass.Domain;
using BackEndClass.Helpers;
using BackEndClass.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices
{
    public class ProveedorAppService : IProveedorAppService
    {
        private readonly MWSContext _context;
        private readonly ProveedorDomainService _proveedorDomainService;

        public ProveedorAppService(MWSContext context, ProveedorDomainService ProveedorDomainService)
        {
            _context = context;
            _proveedorDomainService = proveedorDomainService;
        }

        public IEnumerable<Proveedor> GetAll()
        {
            return _context.Proveedor.Where(x => x.Estado == Constantes.Activo);
        }

        public async Task<Response> GetById(long id)
        {
            var proveedor = await _context.Proveedor.FirstOrDefaultAsync(r => r.Id == id);
            if (proveedor == null)
            {
                return new Response { Mensaje = "Este Proveedor no existe" };
            }

            return new Response { Datos = proveedor };
        }

        public async Task<Response> PostProveedor(Proveedor proveedor)
        {
            string mensaje = _proveedorDomainService.ValidateFirstName(proveedor.Nombre);
            if (!String.IsNullOrEmpty(mensaje))
            {
                return new Response { Mensaje = mensaje };
            }

            mensaje = _proveedorDomainService.ValidateLastName(proveedor.Apellido);
            if (!String.IsNullOrEmpty(mensaje))
            {
                return new Response { Mensaje = mensaje };
            }


            var SavedUser = await _context.Proveedor.FirstOrDefaultAsync(r => r.Nombre == proveedor.Nombre);
            if (SavedUser != null)
            {
                return new Response { Mensaje = "Este proveedor ya existe en el sistema" };
            }

            _context.Proveedor.Add(proveedor);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Proveedor agregado correctamente" };
        }


        public async Task<Response> DeleteProveedor(int id)
        {
            var proveedor = await _context.Proveedor.FindAsync(id);
            if (proveedor == null)
            {
                return new Response { Mensaje = $"No tenemos un proveedor con ese id" }; ;
            }
            proveedor.Estado = 0;
            _context.Entry(proveedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Proveedor {proveedor.Nombre} eliminado correctamente" };
        }


        public async Task<Response> PutProveedor(Proveedor proveedor)
        {
            _context.Entry(proveedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Proveedor {proveedor.Nombre} modificado correctamente" };
        }
    }
}
