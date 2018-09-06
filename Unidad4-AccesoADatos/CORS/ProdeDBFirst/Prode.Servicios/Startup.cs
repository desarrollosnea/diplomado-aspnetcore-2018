using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProdeDBFirst.Datos;
using ProdeDBFirst.Datos.Interface;
using ProdeDBFirst.Entidades;
using ProdeDBFirst.Negocio;
using ProdeDBFirst.Negocio.Interfaces;

namespace Prode.Servicios
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
            var connection = @"Server=.;Database=ProDe;Trusted_Connection=True;";
            services.AddDbContext<ProDeContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IPartidoNegocio, PartidoNegocio>();
            services.AddScoped<IPartidoRepository, PartidoRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            var secret = Configuration["Auth:Secret"];
            var issuer = Configuration["Auth:Issuer"];
            var audience = Configuration["Auth:Audience"];

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = issuer,       //"http://localhost:9100", 
                        ValidAudience = audience,   //"StarWarsAPI",
                        IssuerSigningKey = new SymmetricSecurityKey(
                                                Encoding.UTF8.GetBytes(secret))
                    };
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // global policy - assign here or on each controller
            //app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
