using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models.DTOs
{
    public class TipoServicioDTO
    {
        public int id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public int Estado { get; set; }

        public static TipoServicioDTO DeModeloADTO(TipoServicio tipoServicio)
        {
            return tipoServicio != null ? new TipoServicioDTO
            {
                id = tipoServicio.id,
                Descripcion = tipoServicio.Descripcion,
                Tipo = tipoServicio.Tipo,
                Estado = tipoServicio.Estado
            } : null;
        }

        public static IEnumerable<TipoServicioDTO> DeModeloADTO(IEnumerable<TipoServicio> tipoServicio)
        {
            if (tipoServicio == null)
            {
                return new List<TipoServicioDTO>();
            }
            List<TipoServicioDTO> tiposServicioData = new List<TipoServicioDTO>();

            foreach (var item in tipoServicio)
            {
                tiposServicioData.Add(DeModeloADTO(item));
            }

            return tiposServicioData;
        }

        public static TipoServicio DeDTOAModelo(TipoServicioDTO tipoServicioDTO)
        {
            return tipoServicioDTO != null ? new TipoServicio.Builder(tipoServicioDTO.Descripcion, tipoServicioDTO.Tipo).conEstado(tipoServicioDTO.Estado).Construir() : null;
        }
    }
}
