using System.Collections.Generic;

namespace BackEndClass.Models.DTOs
{
    public class TipoArticuloDTO
    {
        public int id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public int Estado { get; set; }

        public static TipoArticuloDTO DeModeloADTO(TipoArticulo tipoArticulo)
        {
            return tipoArticulo != null ? new TipoArticuloDTO
            {
                id = tipoArticulo.id,
                Descripcion = tipoArticulo.Descripcion,
                Tipo = tipoArticulo.Tipo,
                Estado = tipoArticulo.Estado
            } : null;
        }

        public static IEnumerable<TipoArticuloDTO> DeModeloADTO(IEnumerable<TipoArticulo> tipoArticulo)
        {
            if (tipoArticulo == null)
            {
                return new List<TipoArticuloDTO>();
            }
            List<TipoArticuloDTO> tiposArticuloData = new List<TipoArticuloDTO>();

            foreach (var item in tipoArticulo)
            {
                tiposArticuloData.Add(DeModeloADTO(item));
            }

            return tiposArticuloData;
        }

        public static TipoArticulo DeDTOAModelo(TipoArticuloDTO tipoArticuloDTO)
        {
            return tipoArticuloDTO != null ? new TipoArticulo.Builder(tipoArticuloDTO.Descripcion, tipoArticuloDTO.Tipo).conEstado(tipoArticuloDTO.Estado).Construir() : null;
        }
    }




}
