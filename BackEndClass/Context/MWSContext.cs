using BackEndClass.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public DbSet<Usuario> User { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Proveedor> Provider { get; set; }
        //public DbSet<MasterProvider> MasterProvider { get; set; }
        public DbSet<Recomendacion> Recomendation { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.UseSqlServer(@"Server=38.17.54.162,51688;Database=MechanicalWorkShopSystem30042021;User Id=devops;Password=Yf4-Sf");
            optionBuilder.UseSqlServer(@"Server=38.17.54.162,51688;Database=MechanicalWorkShopSystem30042021;User Id=tempWork;Password=Temp123456");
        }
    }
}
