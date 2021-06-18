using System.Collections.Generic;

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
        public string Image { get; set; }

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
                Direccion = proveedor.Direccion,
                Estado = proveedor.Estado,
                Image = proveedor.Image
            } : null;
        }

        public static IEnumerable<ProveedorDTO> DeModeloADTO(IEnumerable<Proveedor> proveedores)
        {
            if(proveedores == null)
            {
                return new List<ProveedorDTO>();
            }

            List<ProveedorDTO> proveedoresData = new List<ProveedorDTO>();

            foreach (var item in proveedores)
            {
                proveedoresData.Add(DeModeloADTO(item));
            }

            return proveedoresData;
        }

        public static Proveedor DeDTOAModelo(ProveedorDTO proveedorDTO)
        {
            return proveedorDTO != null ? new Proveedor.Builder(proveedorDTO.Nombre, 
                                                                proveedorDTO.Apellido, 
                                                                proveedorDTO.Email, 
                                                                proveedorDTO.Telefono, 
                                                                proveedorDTO.Empresa, 
                                                                proveedorDTO.Direccion,
                                                                proveedorDTO.Image).conEstado(proveedorDTO.Estado).Construir() : null;
        }
    }
}