using BackEndClass.AppServices;
using BackEndClass.AppServices.Interfaces;
using BackEndClass.Context;
using BackEndClass.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy",
                                builder =>
                                {
                                    builder.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader();
                                });
            });
            //services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            //{
            //    builder.AllowAnyOrigin()
            //           .AllowAnyMethod()
            //           .AllowAnyHeader();
            //}));

            services.AddDbContext<MWSContext>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackEndClass", Version = "v1" });
            });



            //Aplication Services
            services.AddScoped<IServicioAppService, ServicioAppService>();       
            services.AddScoped<ITipoArticuloAppService, TipoArticuloAppService>();  
            services.AddScoped<ITipoServicioAppService, TipoServicioAppService>(); 
            services.AddScoped<ITipoUsuarioAppService, TipoUsuarioAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IProveedorAppService, ProveedorAppService>();
            services.AddScoped<IArticuloAppService, ArticuloAppService>();



            //Domain Services
            services.AddScoped<ServicioDomainService>();
            services.AddScoped<TipoArticuloDomainService>();
            services.AddScoped<TipoServicioDomainService>();
            services.AddScoped<TipoUsuarioDomainService>();
            services.AddScoped<UsuarioDomainService>();
            services.AddScoped<ArticuloDomainService>();
            services.AddScoped<ProveedorDomainService>();

            //Controlers
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackEndClass v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
