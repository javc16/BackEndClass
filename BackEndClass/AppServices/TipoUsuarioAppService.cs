using BackEndClass.AppServices.Interfaces;
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
    public class TipoUsuarioAppService: ITipoUsuarioAppService
    {
        private readonly MWSContext _context;
        private readonly TipoUsuarioDomainService _userTypeDomainService;

        public TipoUsuarioAppService(MWSContext context, TipoUsuarioDomainService userTypeDomainService)
        {
            _context = context;
            _userTypeDomainService = userTypeDomainService;
        }

        public IEnumerable<TipoUsuarioDTO> GetAll()
        {
            var tiposDeUsuario =_context.TipoUsuario.Where(x => x.Estado==Constantes.Activo);
            var tiposDeusuarioDTO = TipoUsuarioDTO.DeModeloADTO(tiposDeUsuario);
            return tiposDeusuarioDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var tipoUsuario = await _context.TipoUsuario.FirstOrDefaultAsync(r => r.Id == id);
            if (tipoUsuario == null)
            {
                return new Response { Mensaje = "Este tipo de usuario no existe" };
            }
            var data = TipoUsuarioDTO.DeModeloADTO(tipoUsuario);
            return new Response { Datos = data };
        }

        public async Task<Response> PostTipoUsuario(TipoUsuarioDTO tipoUsuarioDTO)
        {
            string mensaje = _userTypeDomainService.ValidarDescripcion(tipoUsuarioDTO.Descripcion);
            if (!mensaje.Equals(Constantes.ValidacionConExito)) 
            {
                return new Response { Mensaje = mensaje };
            }                
            
            var SavedUser = await _context.TipoUsuario.FirstOrDefaultAsync(r => r.Descripcion == tipoUsuarioDTO.Descripcion);
            if (SavedUser != null)
            {
                return new Response { Mensaje = "Este tipo de usuario ya existe en el sistema" };
            }
            var tipoUsuario = TipoUsuarioDTO.DeDTOAModelo(tipoUsuarioDTO);
            _context.TipoUsuario.Add(tipoUsuario);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Tipo de Usuario agregado correctamente" };
        }

        public async Task<Response> PutTipoUsuario(TipoUsuarioDTO tipoUsuarioDTO)
        {
            var tipoUsuario = TipoUsuarioDTO.DeDTOAModelo(tipoUsuarioDTO);

            _context.Entry(tipoUsuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Usuario {tipoUsuario.Descripcion} modificado correctamente" };
        }

        public async Task<Response> DeleteTipoUsuario(TipoUsuarioDTO tipoUsuarioDTO)
        {
            var tipoUsuario = await _context.TipoUsuario.FindAsync(tipoUsuarioDTO.Id);
            if (tipoUsuario == null)
            {
                return new Response { Mensaje = $"No tenemos un tipo de usuario con id {tipoUsuarioDTO.Id}" }; ;
            }
            tipoUsuario.Estado = Constantes.Inactivo;
            _context.Entry(tipoUsuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Usuario {tipoUsuario.Descripcion} eliminado correctamente" };
        }

       
    }
}
