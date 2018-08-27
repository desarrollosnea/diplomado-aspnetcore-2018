using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades.DB;
using Core.Negocio.Partido;
using Core.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PRODEDBFirst.Controllers
{
    public class PartidoController : Controller
    {
        private readonly ProDeContext _context;

		public IPartidoNegocio PartidoNegocio;

        public PartidoController(ProDeContext context,IPartidoNegocio partidoNegocio)
        {
            _context = context;
			PartidoNegocio = partidoNegocio;
        }

        // GET: Partido
        public async Task<IActionResult> Index()
        {

			var partidos = await PartidoNegocio.BuscarPartido(null, null, null, null);
			var listaPartidos = new List<PartidoCompleto>();
			foreach (var partido in partidos)
			{
				var partidoCompleto = new PartidoCompleto
				{
					Fase = partido.Fase,
					Local = partido.Local,
					Visitante = partido.Visitante,
					GolesLocal = partido.GolesLocal,
					GolesVisitante = partido.GolesVisitante

				};
				listaPartidos.Add(partidoCompleto);
			}

			var local = partidos[0].TorneoDescripcion;

			return View(listaPartidos);
        }
		
    }
}
