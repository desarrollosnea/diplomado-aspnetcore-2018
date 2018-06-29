using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prode.Core.Entidades;
using Prode.Core.Entidades.Interfaces;

namespace ProdeWebApp.Controllers
{
    public class EquipoController : Controller
    {
        private IFormateador _formateador;

        public EquipoController(IFormateador formateador,)
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


            ViewData["Nombre"] = _formateador.NombreCompleto(argentina);

            return View();
        }
    }
}