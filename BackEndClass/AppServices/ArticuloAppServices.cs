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
    public class ArticuloAppService
    {
        private readonly MWSContext _context;
        private readonly ArticuloDomainService _ArticuloDomainService;

        public ArticuloAppService(MWSContext context, ArticuloDomainService ArticuloDomainService)
        {
            _context = context;
            _ArticuloDomainService = ArticuloDomainService;
        }

        public IEnumerable<Articulo> GetAll()
        {
            return _context.Articulo.Where(x => x.Estado == Constantes.Activo);
        }

        public async Task<Response> GetById(long id)
        {
            var Articulo = await _context.Articulo.FirstOrDefaultAsync(r => r.id == id);
            if (Articulo == null)
            {
                return new Response { Mensaje = "Este articulo no existe" };
            }

            return new Response { Datos = Articulo };
        }

        public async Task<Response> PostArticulo(Articulo Articulo)
        {
            string mensaje = _ArticuloDomainService.ValidarDescripcion(Articulo.Descripcion);
            if (!String.IsNullOrEmpty(mensaje))
            {
                return new Response { Mensaje = mensaje };
            }

            var GuardarArticulo = await _context.Articulo.FirstOrDefaultAsync(r => r.Descripcion == Articulo.Descripcion);
            if (GuardarArticulo != null)
            {
                return new Response { Mensaje = "Este articulo ya existe en el sistema" };
            }

            _context.TipoArticulo.Add(Articulo);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Articulo agregado correctamente" };
        }

        public async Task<Response> PutArticulo(Articulo Articulo)
        {
            _context.Entry(Articulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $" Articulo {Articulo.Descripcion} modificado correctamente" };
        }

        public async Task<Response> DeleteArticulo(int id)
        {
            var Articulo = await _context.Servicio.FindAsync(id);
            if (Articulo == null)
            {
                return new Response { Mensaje = $"No tenemos un articulo con ese id" }; ;
            }
            Articulo.Estado = 0;
            _context.Entry(tipoArticulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Articulo {Articulo.Descripcion} eliminado correctamente" };
        }
    }
}
