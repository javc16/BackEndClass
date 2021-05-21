using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models.DTOs
{
    public class ServicioDTO
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Alias { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }

        public static ServicioDTO DeModeloADTO(Servicio servicio)
        {
            return servicio != null ? new ServicioDTO
            {
                id = servicio.id,
                Nombre = servicio.Nombre,
                Descripcion = servicio.Descripcion,
                Alias = servicio.Alias,
                Precio = servicio.Precio,
                Estado = servicio.Estado
            } : null;
        }

        public static IEnumerable<ServicioDTO> DeModeloADTO(IEnumerable<Servicio> servicios)
        {
            if(servicios == null)
            {
                return new List<ServicioDTO>();
            }

            List<ServicioDTO> serviciosData = new List<ServicioDTO>();

            foreach (var item in servicios)
            {
                serviciosData.Add(DeModeloADTO(item));
            }

            return serviciosData;
        }

        public static Servicio DeDTOAModelo(ServicioDTO servicioDTO)
        {
            return servicioDTO != null ? new Servicio.Builder(servicioDTO.Descripcion,servicioDTO.Alias,servicioDTO.Precio,servicioDTO.Nombre).conEstado(servicioDTO.Estado).Construir() : null;
        }
    }
}