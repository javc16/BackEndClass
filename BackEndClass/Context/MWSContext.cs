using BackEndClass.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndClass.Context
{
    public class MWSContext : DbContext
    {
        public MWSContext(DbContextOptions<MWSContext> options) : base(options)
        {

        }

        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<TipoArticulo> TipoArticulo { get; set; }
        public DbSet<TipoServicio> TipoServicio { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        //public DbSet<MasterProvider> MasterProvider { get; set; }
        public DbSet<Recomendacion> Recomendacion { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=38.17.54.162,51688;Database=MWS;User Id=sa;Password=UM3LgE");
            //optionBuilder.UseSqlServer(@"Server=DESKTOP-AICR3S2;Database=Cliente;User Id=sa;Password=1234");
        }
    }
}
