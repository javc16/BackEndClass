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
    public class TipoUsuarioAppService: ITipoUsuarioAppService
    {
        private readonly MWSContext _context;
        private readonly TipoUsuarioDomainService _userTypeDomainService;

        public TipoUsuarioAppService(MWSContext context, TipoUsuarioDomainService userTypeDomainService)
        {
            _context = context;
            _userTypeDomainService = userTypeDomainService;
        }

        public IEnumerable<TipoUsuario> GetAll()
        {
            return _context.TipoUsuario.Where(x => x.Estado==Constantes.Activo);
        }

        public async Task<Response> GetById(long id)
        {
            var tipoUsuario = await _context.TipoUsuario.FirstOrDefaultAsync(r => r.Id == id);
            if (tipoUsuario == null)
            {
                return new Response { Mensaje = "Este tipo de usuario no existe" };
            }

            return new Response { Datos = tipoUsuario };
        }

        public async Task<Response> PostTipoUsuario(TipoUsuario tipoUsuario)
        {
            string mensaje = _userTypeDomainService.ValidarDescripcion(tipoUsuario.Descripcion);
            if (!String.IsNullOrEmpty(mensaje)) 
            {
                return new Response { Mensaje = mensaje };
            }                
            
            var SavedUser = await _context.TipoUsuario.FirstOrDefaultAsync(r => r.Descripcion == tipoUsuario.Descripcion);
            if (SavedUser != null)
            {
                return new Response { Mensaje = "Este tipo de usuario ya existe en el sistema" };
            }

            _context.TipoUsuario.Add(tipoUsuario);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Tipo de Usuario agregado correctamente" };
        }

        public async Task<Response> PutTipoUsuario(TipoUsuario tipoUsuario)
        {
            _context.Entry(tipoUsuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Usuario {tipoUsuario.Descripcion} modificado correctamente" };
        }

        public async Task<Response> DeleteTipoUsuario(int id)
        {
            var tipoUsuario = await _context.TipoUsuario.FindAsync(id);
            if (tipoUsuario == null)
            {
                return new Response { Mensaje = $"No tenemos un tipo de usuario con ese id" }; ;
            }
            tipoUsuario.Estado = 0;
            _context.Entry(tipoUsuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Usuario {tipoUsuario.Descripcion} eliminado correctamente" };
        }

       
    }
}
