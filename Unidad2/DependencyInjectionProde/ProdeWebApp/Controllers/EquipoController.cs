using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Prode.Core.Entidades;
using Prode.Core.Entidades.Interfaces;

namespace ProdeWebApp.Controllers
{
    public class EquipoController : Controller
    {
        private IFormateador _formateador;

        private IHostingEnvironment _environment;


        public EquipoController(IFormateador formateador,
                                IHostingEnvironment environment)
        {
            _formateador = formateador;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var argentina = new Equipo()
            {
                Nombre = $"Argentina {_environment.EnvironmentName}",
                Abreviatura = "ARG"
            };


            ViewData["Nombre"] = _formateador.NombreCompleto(argentina);

            return View();
        }


        public IActionResult Index2()
        {
            var otroFormateador = 
                (IFormateador)HttpContext.RequestServices.GetService(typeof(IFormateador));

            var argentina = new Equipo()
            {
                Nombre = $"Argentina {_environment.EnvironmentName}",
                Abreviatura = "ARG"
            };


            ViewData["Nombre"] = otroFormateador.NombreCompleto(argentina);

            return View();
        }
    }
}