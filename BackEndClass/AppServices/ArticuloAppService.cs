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
    public class ArticuloAppService: IArticuloAppService
    {
        private readonly MWSContext _context;
        private readonly ArticuloDomainService _ArticuloDomainService;

        public ArticuloAppService(MWSContext context, ArticuloDomainService ArticuloDomainService)
        {
            _context = context;
            _ArticuloDomainService = ArticuloDomainService;
        }

        public IEnumerable<ArticuloDTO> GetAll()
        {
             var Articulo = _context.Articulo.Where(x => x.Estado == Constantes.Activo);
            var articuloDTO = ArticuloDTO.DeModeloADTO(Articulo);
            return articuloDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var Articulo = await _context.Articulo.FirstOrDefaultAsync(r => r.Id == id);
            if (Articulo == null)
            {
                return new Response { Mensaje = "Este tipo de articulo no existe" };
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
                return new Response { Mensaje = "Este tipo de articulo ya existe en el sistema" };
            }

            _context.Articulo.Add(Articulo);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Tipo de Articulo agregado correctamente" };
        }

        public async Task<Response> PutArticulo(Articulo Articulo)
        {
            _context.Entry(Articulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Articulo {Articulo.Descripcion} modificado correctamente" };
       
        }

        public async Task<Response> DeleteArticulo(int id)
        {
            var Articulo = await _context.Articulo.FindAsync(id);
            if (Articulo == null)
            {
                return new Response { Mensaje = $"No tenemos un tipo de articulo con ese id" }; ;
            }
            Articulo.Estado = 0;
            _context.Entry(Articulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Articulo {Articulo.Descripcion} eliminado correctamente" };
        }
    }
}
