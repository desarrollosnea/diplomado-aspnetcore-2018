using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                switch (context.Request.Path)
                {
                    case "/":
                        var sb = new StringBuilder();
                        sb.Append("<html>");
                        sb.Append("<head>");
                        sb.Append("<title> Ole | Diplomado ASP.NET Core 2.1</title>");
                        sb.Append("</head>");
                        sb.Append("<body>");
                        sb.Append("<h1>Hola Diplomado</h1>");
                        sb.Append("</body>");
                        sb.Append("</html>");

                        await context.Response.WriteAsync(sb.ToString());
                        break;
                    case "/demo.html":
                        var htmlContenido = System.IO.File.ReadAllText("demo.html");
                        await context.Response.WriteAsync(htmlContenido);
                        break;
                    case "/demo.js":
                        var jsContenido = System.IO.File.ReadAllText("demo.js");
                        await context.Response.WriteAsync(jsContenido);
                        break;
                    default:
                        context.Response.StatusCode = 404;
                        break;
                }
               
            });
        }
    }
}
