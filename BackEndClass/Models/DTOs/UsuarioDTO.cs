using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int Estado { get; set; }

        public static UsuarioDTO DeModeloADTO(Usuario usuario)
        {
            return usuario != null ? new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                Estado = usuario.Estado
            } : null;
        }

        public static IEnumerable<UsuarioDTO> DeModeloADTO(IEnumerable<Usuario> usuario)
        {
            if (usuario == null)
            {
                return new List<UsuarioDTO>();
            }
            List<UsuarioDTO> usuarioData = new List<UsuarioDTO>();

            foreach (var item in usuario)
            {
                usuarioData.Add(DeModeloADTO(item));
            }

            return usuarioData;
        }

        public static Usuario DeDTOAModelo(UsuarioDTO usuarioDTO)
        {
            return usuarioDTO != null ? new Usuario.Builder(usuarioDTO.Nombre,
                                                            usuarioDTO.Apellido,
                                                            usuarioDTO.Email,
                                                            usuarioDTO.Telefono ).conEstado(usuarioDTO.Estado).Construir() : null;
        }
    }
}
