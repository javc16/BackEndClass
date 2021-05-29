using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BackEndClass.Models.DTOs
{
    public class ArticuloDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Alias { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }
        public int IdArticulo { get; set; }

        public static ArticuloDTO DeModeloADTO(Articulo articulo) 
        {
            return articulo != null ? new ArticuloDTO 
            {
                Id = articulo.Id,
                Nombre = articulo.Nombre,
                Descripcion = articulo.Descripcion,
                Precio = articulo.Precio
            }:null;
        }

        public static IEnumerable<ArticuloDTO> DeModeloADTO(IEnumerable<Articulo> articulo)
        {
            if (articulo == null) 
            {
                return new List<ArticuloDTO>();
            }
            List<ArticuloDTO> articuloData = new List<ArticuloDTO>();

            foreach (var item in articulo) 
            {
                articuloData.Add(DeModeloADTO(item));
            }

            return articuloData;
        }


        public static Articulo DeDTOAModelo(Articulo articuloDTO)
        {
            return articuloDTO != null ? new Articulo.Builder(articuloDTO.Id).conNombre(articuloDTO.Nombre).conDescripcion(articuloDTO.Descripcion).conPrecio(articuloDTO.Precio).Constuir() : null;
        }
    }

    
}

    

