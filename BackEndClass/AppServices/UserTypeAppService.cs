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
    public class UserTypeAppService
    {
        private readonly MWSContext _context;
        private readonly TipoUsuarioDomainService _userTypeDomainService;

        public UserTypeAppService(MWSContext context, TipoUsuarioDomainService userTypeDomainService)
        {
            _context = context;
            _userTypeDomainService = userTypeDomainService;
        }

        public async Task<IEnumerable<TipoUsuario>> GetAll()
        {
            return await _context.TipoUsuario.ToListAsync();
        }

        public async Task<Response> GetById(long id)
        {
            var tipoUsuario = await _context.TipoUsuario.FirstOrDefaultAsync(r => r.Id == id);
            if (tipoUsuario == null)
            {
                return new Response { Message = "Este tipo de usuario no existe" };
            }

            return new Response { Data = tipoUsuario };
        }

        public async Task<Response> PostUserType(TipoUsuario tipoUsuario)
        {
            string mensaje = _userTypeDomainService.ValidarDescripcion(tipoUsuario.Descripcion);
            if (!String.IsNullOrEmpty(mensaje)) 
            {
                return new Response { Message = mensaje };
            }                
            
            var SavedUser = await _context.TipoUsuario.FirstOrDefaultAsync(r => r.Descripcion == tipoUsuario.Descripcion);
            if (SavedUser != null)
            {
                return new Response { Message = "Este tipo de usuario ya existe en el sistema" };
            }

            _context.TipoUsuario.Add(tipoUsuario);
            await _context.SaveChangesAsync();
            return new Response { Message = "Tipo de Usuario agregado correctamente" };
        }

        public async Task<Response> PutUserType(TipoUsuario tipoUsuario)
        {
            _context.Entry(tipoUsuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Message = $"Tipo de Usuario {tipoUsuario.Descripcion} modificado correctamente" };
        }

        public async Task<Response> DeleteUserType(int id)
        {
            var tipoUsuario = await _context.TipoUsuario.FindAsync(id);
            if (tipoUsuario == null)
            {
                return new Response { Message = $"No have a provider with this id" }; ;
            }
            
            _context.Entry(tipoUsuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Message = $"Tipo de Usuario {tipoUsuario.Descripcion} elinado correctamente" };
        }
    }
}
