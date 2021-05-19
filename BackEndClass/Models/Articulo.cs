using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BackEndClass.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Alias { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }

        public sealed class Builder 
        {
            private readonly Articulo _articulo;

            public Builder(int id ) 
            {
                _articulo = new Articulo
                {
                    Id = id
                };   
            }

            public Builder conNombre(string nombre) 
            {
                _articulo.Nombre = nombre;
                return this;
            }
            public Builder conDescripcion(string descripcion) 
            {
                _articulo.Descripcion = descripcion;
                return this;
            }

            public Builder conPrecio(decimal precio) 
            {
                _articulo.Precio = precio;
                return this;
            }
            public Articulo Constuir() 
            {
                return _articulo;
            }
        }

    }
}