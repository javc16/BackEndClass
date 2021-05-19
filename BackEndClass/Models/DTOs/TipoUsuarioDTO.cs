using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models.DTOs
{
    public class TipoUsuarioDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public static TipoUsuarioDTO DeModeloADTO(TipoUsuario tipoUsuario) 
        {
            return tipoUsuario != null ? new TipoUsuarioDTO 
            {
                Id = tipoUsuario.Id,
                Descripcion = tipoUsuario.Descripcion,
                Estado = tipoUsuario.Estado
            }:null;
        }

        public static IEnumerable<TipoUsuarioDTO> DeModeloADTO(IEnumerable<TipoUsuario> tiposUsuario)
        {
            if (tiposUsuario == null) 
            {
                return new List<TipoUsuarioDTO>();
            }
            List<TipoUsuarioDTO> tiposUsuarioData = new List<TipoUsuarioDTO>();

            foreach (var item in tiposUsuario) 
            {
                tiposUsuarioData.Add(DeModeloADTO(item));
            }

            return tiposUsuarioData;
        }


        public static TipoUsuario DeDTOAModelo(TipoUsuarioDTO tipoUsuarioDTO)
        {
            return tipoUsuarioDTO != null ? new TipoUsuario.Builder(tipoUsuarioDTO.Descripcion).conEstado(tipoUsuarioDTO.Estado).Constuir() : null;
        }
    }

    
}
