using System.Collections.Generic;

namespace BackEndClass.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int Estado { get; set; }
        public int IdTipoUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        List<Recomendacion> Recomendaciones { get; set; }
        public sealed class Builder
        {
            private readonly Usuario _usuario;

            public Builder(string nombre, string apellido, string email, string telefono)
            {
                _usuario = new Usuario
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Email = email,
                    Telefono = telefono
                };
            }

            public Builder conEstado(int estado)
            {
                _usuario.Estado = estado;
                return this;
            }

            public Usuario Construir()
            {
                return _usuario;
            }
        }
    }
}
