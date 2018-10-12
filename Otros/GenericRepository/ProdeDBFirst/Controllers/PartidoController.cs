using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProdeDBFirst.Entidades;
using ProdeDBFirst.Negocio.Interfaces;

namespace ProdeDBFirst.Controllers
{
    //[ResponseCache(Duration = 60)]
    public class PartidoController : Controller
    {
        private readonly IPartidoNegocio _partidoNegocio;
        private IMemoryCache _cache;

        public PartidoController(IPartidoNegocio partidoNegocio, IMemoryCache cache)
        {
            _partidoNegocio = partidoNegocio;
            _cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            var torneo = _cache.GetOrCreate("torneoSelected", entry =>
            {
                var torneoDefault = new Torneo()
                {
                    TorneoId = 1,
                    Descripcion = "Copa Libertadores"
                };
                return torneoDefault;
            });

            //var ultimaActualizacion = _cache.GetOrCreate("ultimaActualizacion", entry =>
            //{
            //    var date = DateTime.Now;
            //    return date;
            //});

            ViewBag.Torneo = torneo;
            ViewBag.UltimaActualizacion = DateTime.Now;

            return View(await _partidoNegocio.PartidosBuscar(null, null, torneo.TorneoId, null));
        }
    }
}