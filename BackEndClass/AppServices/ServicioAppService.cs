using BackEndClass.Context;
using BackEndClass.Domain;
using BackEndClass.Helpers;
using BackEndClass.Models;
using BackEndClass.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices
{
    public class ServicioAppService: IServicioAppService
    {
        private readonly MWSContext _context;
        private readonly ServicioDomainService _servicioDomainService;

        public ServicioAppService(MWSContext context, ServicioDomainService servicioDomainService)
        {
            _context = context;
            _servicioDomainService = servicioDomainService;
        }

        public IEnumerable<ServicioDTO> GetAll()
        {
            var servicios = _context.Servicio.Where(x => x.Estado==Constantes.Activo);
            var serviciosDTO = ServicioDTO.DeModeloADTO(servicios);
            return serviciosDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var servicio = await _context.Servicio.FirstOrDefaultAsync(r => r.Id == id);
            if (servicio == null)
            {
                return new Response { Mensaje = "Este servicio no existe" };
            }

            var data = ServicioDTO.DeModeloADTO(servicio);
            return new Response { Datos = data };
        }

        public async Task<Response> PostServicio(Servicio servicio)
        {
            string mensaje = _servicioDomainService.ValidarDescripcion(servicio.Descripcion);
            if (!String.IsNullOrEmpty(mensaje))
            {
                return new Response { Mensaje = mensaje };
            }

            var GuardarServicio = await _context.Servicio.FirstOrDefaultAsync(r => r.Nombre == servicio.Nombre);
            if (GuardarServicio != null)
            {
                return new Response { Mensaje = "Este servicio ya existe en el sistema" };
            }

            _context.Servicio.Add(servicio);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Servicio agregado correctamente" };
        }

        public async Task<Response> PutServicio(Servicio servicio)
        {
            _context.Entry(servicio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Servicio {servicio.Nombre} modificado correctamente" };
        }

        public async Task<Response> DeleteServicio(int id)
        {
            var servicio = await _context.Servicio.FindAsync(id);
            if (servicio == null)
            {
                return new Response { Mensaje = $"No tenemos un servicio con ese id" }; ;
            }
            servicio.Estado = 0;
            _context.Entry(servicio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Servicio {servicio.Nombre} eliminado correctamente" };
        }
    }
}
