using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prode.Core.Entidades;
using Prode.Core.Entidades.Interfaces;

namespace ProdeWebApp.Controllers
{
    public class PartidoController : Controller
    {
        private IFormateador _formateador;
        public PartidoController(IFormateador formateador)
        {
            _formateador = formateador;
        }
        public IActionResult Index()
        {
            var argentina = new Equipo()
            {
                Nombre = "Argentina",
                Abreviatura = "ARG"
            };

             var brasil = new Equipo()
             {
                 Nombre = "BRasil",
                 Abreviatura = "BRA"
             };


            ViewData["Nombre1"] = _formateador.NombreCompleto(argentina);
            ViewData["Nombre2"] = _formateador.NombreCompleto(brasil);

            return View();
            return View();
        }
    }
}