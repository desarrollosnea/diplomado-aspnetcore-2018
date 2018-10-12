using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using RazorLight;
using ReporteServicios.Models;

namespace ReporteServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        public IHostingEnvironment HostingEnvironment { get; set; }
        public ReporteController(IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Route("demobasico")]
        public async Task<IActionResult> HtmlToPdfBasico([FromServices] INodeServices nodeServices)
        {
            var html = "<h2>Hola</h2>";
            return await ConvertirHtmlToPdf(nodeServices, html);
        }

        [HttpGet]
        [Route("demopdf")]
        public async Task<IActionResult> HtmlToPdfDemo([FromServices] INodeServices nodeServices)
        {
            var contentRootPath = HostingEnvironment.ContentRootPath;
            var templatePath = Path.Combine(contentRootPath, "recursos\\PartidoTemplate.cshtml");

            var engine = new RazorLightEngineBuilder()
              .UseFilesystemProject(contentRootPath)
              .UseMemoryCachingProvider()
              .Build();

            var model = new List<PartidoCompleto>();
            model.Add(new PartidoCompleto()
            {
                Fecha = DateTime.Now,
                Local = "Independiente",
                Visitante = "River Plate",
                GolesLocal = 0,
                GolesVisitante = 2
            });
            model.Add(new PartidoCompleto()
            {
                Fecha = DateTime.Now,
                Local = "Boca Juniors",
                Visitante = "Cruzeiro",
                GolesLocal = 3,
                GolesVisitante = 1
            });

            var html = await engine.CompileRenderAsync(templatePath, model);

            return await ConvertirHtmlToPdf(nodeServices, html);
        }

       public async Task<IActionResult> ConvertirHtmlToPdf(INodeServices nodeService, string html)
        {
            byte[] bytes;
            try
            {
                bytes = await nodeService.InvokeAsync<byte[]>("./index", html);
                return File(bytes, "application/pdf");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
