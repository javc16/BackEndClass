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
    public class TipoServicioAppService: ITipoServicioAppService
    {
        private readonly MWSContext _context;
        private readonly TipoServicioDomainService _tipoServicioDomainService;

        public TipoServicioAppService(MWSContext context, TipoServicioDomainService tipoServicioDomainService)
        {
            _context = context;
            _tipoServicioDomainService = tipoServicioDomainService;
        }

        public IEnumerable<TipoServicioDTO> GetAll()
        {
            var tiposDeServicio = _context.TipoServicio.Where(x => x.Estado == Constantes.Activo);
            var tiposDeServicioDTO = TipoServicioDTO.DeModeloADTO(tiposDeServicio);
            return tiposDeServicioDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var tipoServicio = await _context.TipoServicio.FirstOrDefaultAsync(r => r.id == id);
            if (tipoServicio == null)
            {
                return new Response { Mensaje = "Este tipo de servicio no existe" };
            }
            var data = TipoServicioDTO.DeModeloADTO(tipoServicio);
            return new Response { Datos = data };
        }

        public async Task<Response> PostTipoServicio(TipoServicioDTO tipoServicioDTO)
        {
            string mensaje = _tipoServicioDomainService.ValidarDescripcion(tipoServicioDTO.Descripcion);
            if (!mensaje.Equals(Constantes.ValidacionConExito))
            {
                return new Response { Mensaje = mensaje };
            }

            var GuardarServicio = await _context.TipoServicio.FirstOrDefaultAsync(r => r.Descripcion == tipoServicioDTO.Descripcion);
            if (GuardarServicio != null)
            {
                return new Response { Mensaje = "Este tipo de servicio ya existe en el sistema" };
            }

            var tipoServicio = TipoServicioDTO.DeDTOAModelo(tipoServicioDTO);
            _context.TipoServicio.Add(tipoServicio);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Tipo de Servicio agregado correctamente" };
        }

        public async Task<Response> PutTipoServicio(TipoServicioDTO tipoServicioDTO)
        {
            _context.Entry(tipoServicioDTO).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Servicio {tipoServicioDTO.Descripcion} modificado correctamente" };
        }

        public async Task<Response> DeleteTipoServicio(TipoServicioDTO tipoServicioDTO)
        {
            var tipoServicio = await _context.TipoArticulo.FindAsync(tipoServicioDTO.id);
            if (tipoServicio == null)
            {
                return new Response { Mensaje = $"No tenemos un tipo de servicio con id {tipoServicioDTO.id}" }; ;
            }
            tipoServicio.Estado = Constantes.Inactivo;
            _context.Entry(tipoServicio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Servicio {tipoServicio.Descripcion} eliminado correctamente" };
        }


    }
}
