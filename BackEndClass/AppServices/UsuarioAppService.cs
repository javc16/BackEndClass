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
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly MWSContext _context;
        private readonly UsuarioDomainService _usuarioDomainService;

        public UsuarioAppService(MWSContext context, UsuarioDomainService usuarioDomainService)
        {
            _context = context;
            _usuarioDomainService = usuarioDomainService;
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            var usuario = _context.Usuario.Where(x => x.Estado == Constantes.Activo);
            var usuarioDTO = UsuarioDTO.DeModeloADTO(usuario);
            return usuarioDTO;
        }

        public async Task<Response> GetById(long id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(r => r.Id == id);
            if (usuario == null)
            {
                return new Response { Mensaje = "Este usuario no existe" };
            }
            var data = UsuarioDTO.DeModeloADTO(usuario);
            return new Response { Datos = data };
        }

        public async Task<Response> PostUsuario(Usuario usuario)
        {
            string mensaje = _usuarioDomainService.ValidarNombre(usuario.Nombre);
            if (!String.IsNullOrEmpty(mensaje))
            {
                return new Response { Mensaje = mensaje };
            }

            mensaje = _usuarioDomainService.ValidarApellido(usuario.Apellido);
            if (!String.IsNullOrEmpty(mensaje))
            {
                return new Response { Mensaje = mensaje };
            }


            var SavedUser = await _context.Usuario.FirstOrDefaultAsync(r => r.Nombre == usuario.Nombre);
            if (SavedUser != null)
            {
                return new Response { Mensaje = "Este usuario ya existe en el sistema" };
            }

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Usuario agregado correctamente" };
        }


        public async Task<Response> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return new Response { Mensaje = $"No tenemos un usuario con ese id" }; ;
            }
            usuario.Estado = 0;
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Usuario {usuario.Nombre} eliminado correctamente" };
        }


        public async Task<Response> PutUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Usuario {usuario.Nombre} modificado correctamente" };
        }
    }
}
