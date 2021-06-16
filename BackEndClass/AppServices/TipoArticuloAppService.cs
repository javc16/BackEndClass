using BackEndClass.Context;
using BackEndClass.Models.DTOs;
using BackEndClass.Domain;
using BackEndClass.Helpers;
using BackEndClass.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndClass.AppServices.Interfaces;

namespace BackEndClass.AppServices
{
    public class TipoArticuloAppService: ITipoArticuloAppService
    {
        private readonly MWSContext _context;
        private readonly TipoArticuloDomainService _tipoArticuloDomainService;

        public TipoArticuloAppService(MWSContext context, TipoArticuloDomainService tipoArticuloDomainService)
        {
            _context = context;
            _tipoArticuloDomainService = tipoArticuloDomainService;
        }

        public IEnumerable<TipoArticuloDTO> GetAll()
        {
            var tiposDeArticulo = _context.TipoArticulo.Where(x => x.Estado == Constantes.Activo);
            var tiposDeArticuloDTO = TipoArticuloDTO.DeModeloADTO(tiposDeArticulo);
            return tiposDeArticuloDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var tipoArticulo = await _context.TipoArticulo.FirstOrDefaultAsync(r => r.id == id);
            if (tipoArticulo == null)
            {
                return new Response { Mensaje = "Este tipo de articulo no existe" };
            }
            var data = TipoArticuloDTO.DeModeloADTO(tipoArticulo);
            return new Response { Datos = data };
        }

        public async Task<Response> PostTipoArticulo(TipoArticuloDTO tipoArticuloDTO)
        {
            string mensaje = _tipoArticuloDomainService.ValidarDescripcion(tipoArticuloDTO.Descripcion);
            if (!mensaje.Equals(Constantes.ValidacionConExito))
            {
                return new Response { Mensaje = mensaje };
            }

            var GuardarArticulo = await _context.TipoArticulo.FirstOrDefaultAsync(r => r.Descripcion == tipoArticuloDTO.Descripcion);
            if (GuardarArticulo != null)
            {
                return new Response { Mensaje = "Este tipo de articulo ya existe en el sistema" };
            }
            var tipoArticulo = TipoArticuloDTO.DeDTOAModelo(tipoArticuloDTO);
            _context.TipoArticulo.Add(tipoArticulo);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Tipo de Articulo agregado correctamente" };
        }

        public async Task<Response> PutTipoArticulo(TipoArticuloDTO tipoArticuloDTO)
        {
            _context.Entry(tipoArticuloDTO).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Articulo {tipoArticuloDTO.Descripcion} modificado correctamente" };
       
        }

        public async Task<Response> DeleteTipoArticulo(TipoArticuloDTO tipoArticuloDTO)
        {
            var tipoArticulo = await _context.TipoArticulo.FindAsync(tipoArticuloDTO.id);
            if (tipoArticulo == null)
            {
                return new Response { Mensaje = $"No tenemos un tipo de articulo con id {tipoArticuloDTO.id}" }; ;
            }
            tipoArticulo.Estado = Constantes.Inactivo;
            _context.Entry(tipoArticulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Articulo {tipoArticulo.Descripcion} eliminado correctamente" };
        }
    }
}
