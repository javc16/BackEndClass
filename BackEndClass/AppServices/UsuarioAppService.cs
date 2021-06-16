using BackEndClass.AppServices.Interfaces;
using BackEndClass.Context;
using BackEndClass.Domain;
using BackEndClass.Helpers;
using BackEndClass.Models;
using BackEndClass.Models.DTOs;
using Microsoft.EntityFrameworkCore;
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
            var usuarios = _context.Usuario.Where(x => x.Estado == Constantes.Activo);
            var usuariosDTO = UsuarioDTO.DeModeloADTO(usuarios);
            return usuariosDTO;
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

        public async Task<Response> PostUsuario(UsuarioDTO usuarioDTO)
        {
            string mensaje = _usuarioDomainService.ValidarNombre(usuarioDTO.Nombre);
            if (!mensaje.Equals(Constantes.ValidacionConExito))
            {
                return new Response { Mensaje = mensaje };
            }

            mensaje = _usuarioDomainService.ValidarApellido(usuarioDTO.Apellido);
            if (!mensaje.Equals(Constantes.ValidacionConExito))
            {
                return new Response { Mensaje = mensaje };
            }


            var GuardarUsuario = await _context.Usuario.FirstOrDefaultAsync(r => r.Nombre == usuarioDTO.Nombre);
            if (GuardarUsuario != null)
            {
                return new Response { Mensaje = "Este usuario ya existe en el sistema" };
            }
            var usuario = UsuarioDTO.DeDTOAModelo(usuarioDTO);
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Usuario agregado correctamente" };
        }


        public async Task<Response> DeleteUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = await _context.Usuario.FindAsync(usuarioDTO.Id);
            if (usuario == null)
            {
                return new Response { Mensaje = $"No tenemos un usuario con id {usuarioDTO.Id}" }; ;
            }
            usuario.Estado = Constantes.Inactivo;
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Usuario {usuario.Nombre} eliminado correctamente" };
        }


        public async Task<Response> PutUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = UsuarioDTO.DeDTOAModelo(usuarioDTO);

            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Usuario {usuario.Nombre} modificado correctamente" };
        }
    }
}
