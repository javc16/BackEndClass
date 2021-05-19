using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Models.DTOs
{
    public class ProveedorDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Empresa { get; set; }
        public string Direccion { get; set; }
        public int Estado { get; set; }

        public static ProveedorDTO DeModeloADTO(Proveedor proveedor)
        {
            return proveedor != null ? new ProveedorDTO
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
                Apellido = proveedor.Apellido,
                Email = proveedor.Email,
                Telefono = proveedor.Telefono,
                Empresa = proveedor.Empresa,
                Direccion = proveedor.Direccion

            } : null;
        }

        public static IEnumerable<ProveedorDTO> DeModeloADTO(IEnumerable<Proveedor> proveedor)
        {
            if(proveedor == null)
            {
                return new List<ProveedorDTO>();
            }

            List<ProveedorDTO> proveedorData = new List<proveedorDTO>();

            foreach (var item in proveedor)
            {
                proveedorData.Add(DeModeloADTO(item));
            }

            return proveedorData;
        }

        public static Proveedor DeDTOAModelo(ProveedorDTO proveedorDTO)
        {
            return proveedorDTO != null ? new Proveedor.Builder(proveedorDTO.Nombre).conEstado(proveedorDTO.Estado).Construir() : null;
        }
    }
}