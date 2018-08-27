using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Datos.Interfaces.Equipo;
using Core.Datos.Interfaces.Partido;
using Core.Datos.Repositorios.Equipo;
using Core.Datos.Repositorios.Partido;
using Core.Entidades.DB;
using Core.Negocio.Equipo;
using Core.Negocio.Interfaces;
using Core.Negocio.Partido;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PRODE_DBFirst
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
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddScoped<IEquipoNegocio, EquipoNegocio>();
			services.AddScoped<IEquipoRepository, EquipoRepository>();

			services.AddScoped<IPartidoNegocio, PartidoNegocio>();
			services.AddScoped<IPartidoRepository, PartidoRepository>();

			var connection = @"Server=.;Database=ProDe;Trusted_Connection=True;";
			services.AddDbContext<ProDeContext>(options => options.UseSqlServer(connection));
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
