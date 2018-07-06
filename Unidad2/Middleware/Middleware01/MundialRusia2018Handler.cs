using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware01
{
    public static class MundialRusia2018Handler
    {
        public static void Handler(IApplicationBuilder app) {

            app.Run(async (context) =>
            {
                var encabezado = new StringValues(new[] { "ASP.NET Core 2.1" });

                context.Response.Headers.Add("Curso", encabezado);

                await context.Response.WriteAsync("Hola Rusia!");

            });
        }
    }
}
