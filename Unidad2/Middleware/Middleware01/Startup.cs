using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Middleware01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.Map("/Mundial-Rusia-2018", MundialRusia2018Handler.Handler);


            app.Use(async (context, next) =>
            {
                //Acciones
                var reloj = Stopwatch.StartNew();

                //Delegar
                await next.Invoke();

                reloj.Stop();

                await context.Response.WriteAsync($"Procesado en {reloj.Elapsed.TotalMilliseconds}");

            });

            //app.Use(async (context,next) =>
            //{
            //    //Acciones

            //    await context.Response.WriteAsync("Metodo 1");

            //    //Delegar
            //    await next.Invoke();

            //    await context.Response.WriteAsync("Metodo 1 FIN");

            //});

            //app.Use(async (context, next) =>
            //{
            //    //Acciones

            //    await context.Response.WriteAsync("Metodo 2");

            //    //Delegar
            //    await next.Invoke();

            //    await context.Response.WriteAsync("Metodo 2 FIN");


            //});




            app.Use(async (context, next) =>
            {
                //System.Threading.Thread.Sleep(2000);

                //Delegar
                await next.Invoke();

                if (context.Response.StatusCode==404)
                {
                    await context.Response.WriteAsync("Que hacesssss! No existe el archivo");
                }
            });

            app.UseStaticFiles();


            app.Run(async (context) =>
            {
                if (context.Request.Path == "/yoda.html")
                {
                    await context.Response.WriteAsync("Que la fuerza te acompañe!");
                }
                else
                {
                    await context.Response.WriteAsync("Hello World!");
                }
                
            });


        }
    }
}
