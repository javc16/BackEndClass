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
            var articulos = _context.Articulo.Where(x => x.Estado == Constantes.Activo);
            var articulosDTO = ArticuloDTO.DeModeloADTO(articulos);
            return articulosDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var articulo = await _context.Articulo.FirstOrDefaultAsync(r => r.Id == id);
            if (articulo == null)
            {
                return new Response { Mensaje = "Este tipo de articulo no existe" };
            }
            var data = ArticuloDTO.DeModeloADTO(articulo);
            return new Response { Datos = data };
        }

        public async Task<Response> PostArticulo(ArticuloDTO articuloDTO)
        {
            string mensaje = _ArticuloDomainService.ValidarDescripcion(articuloDTO.Descripcion);
            if (!mensaje.Equals(Constantes.ValidacionConExito))
            {
                return new Response { Mensaje = mensaje };
            }

            var GuardarArticulo = await _context.Articulo.FirstOrDefaultAsync(r => r.Descripcion == articuloDTO.Descripcion);
            if (GuardarArticulo != null)
            {
                return new Response { Mensaje = "Este tipo de articulo ya existe en el sistema" };
            }
            var articulo = ArticuloDTO.DeDTOAModelo(articuloDTO);
            _context.Articulo.Add(articulo);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Tipo de Articulo agregado correctamente" };
        }

        public async Task<Response> PutArticulo(ArticuloDTO articuloDTO)
        {
            var articulo = ArticuloDTO.DeDTOAModelo(articuloDTO);

            _context.Entry(articulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Articulo {articulo.Descripcion} modificado correctamente" };

        }

        public async Task<Response> DeleteArticulo(ArticuloDTO articuloDTO)
        {
            var articulo = await _context.Articulo.FindAsync(articuloDTO.Id);
            if (articulo == null)
            {
                return new Response { Mensaje = $"No tenemos un tipo de articulo con ese id" }; ;
            }
            articulo.Estado = 0;
            _context.Entry(articulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Articulo {articulo.Descripcion} eliminado correctamente" };
        }
    }
}
