﻿using BackEndClass.Context;
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
    public class TipoArticuloAppService
    {
        private readonly MWSContext _context;
        private readonly TipoArticuloDomainService _tipoArticuloDomainService;

        public TipoArticuloAppService(MWSContext context, TipoArticuloDomainService tipoArticuloDomainService)
        {
            _context = context;
            _tipoArticuloDomainService = tipoArticuloDomainService;
        }

        public IEnumerable<TipoArticulo> GetAll()
        {
            return _context.TipoArticulo.Where(x => x.Estado == Constantes.Activo);
        }

        public async Task<Response> GetById(long id)
        {
            var tipoArticulo = await _context.TipoArticulo.FirstOrDefaultAsync(r => r.id == id);
            if (tipoArticulo == null)
            {
                return new Response { Mensaje = "Este tipo de articulo no existe" };
            }

            return new Response { Datos = tipoArticulo };
        }

        public async Task<Response> PostTipoArticulo(TipoArticulo tipoArticulo)
        {
            string mensaje = _tipoArticuloDomainService.ValidarDescripcion(tipoArticulo.Descripcion);
            if (!String.IsNullOrEmpty(mensaje))
            {
                return new Response { Mensaje = mensaje };
            }

            var GuardarArticulo = await _context.TipoArticulo.FirstOrDefaultAsync(r => r.Descripcion == tipoArticulo.Descripcion);
            if (GuardarArticulo != null)
            {
                return new Response { Mensaje = "Este tipo de articulo ya existe en el sistema" };
            }

            _context.TipoArticulo.Add(tipoArticulo);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Tipo de Articulo agregado correctamente" };
        }

        public async Task<Response> PutTipoArticulo(TipoArticulo tipoArticulo)
        {
            _context.Entry(tipoArticulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Articulo {tipoArticulo.Descripcion} modificado correctamente" };
       
        }

        public async Task<Response> DeleteTipoArticulo(int id)
        {
            var tipoArticulo = await _context.TipoServicio.FindAsync(id);
            if (tipoArticulo == null)
            {
                return new Response { Mensaje = $"No tenemos un tipo de articulo con ese id" }; ;
            }
            tipoArticulo.Estado = 0;
            _context.Entry(tipoArticulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Tipo de Articulo {tipoArticulo.Descripcion} eliminado correctamente" };
        }
    }
}