using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProdeDBFirst.Models;
using ProdeDBFirst.Negocio.Interfaces;

namespace ProdeDBFirst.Controllers
{
    [ResponseCache(Duration = 60)]
    public class PartidoController : Controller
    {
        private readonly IPartidoNegocio _partidoNegocio;
        private readonly ITorneoNegocio _torneoNegocio;
        private IMemoryCache _cache;

        public PartidoController(IPartidoNegocio partidoNegocio, ITorneoNegocio torneoNegocio, IMemoryCache cache)
        {
            _partidoNegocio = partidoNegocio;
            _torneoNegocio = torneoNegocio;
            _cache = cache;
        }
        
        public async Task<IActionResult> Index()
        {
            var torneo = await
            _cache.GetOrCreateAsync("torneoSelected2", async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromHours(24);
                var torneoId = 1;
                var torneoCompleto = await _torneoNegocio.GetById(torneoId);
                return torneoCompleto;
            });

            ViewBag.TorneoSelected = torneo;
            ViewBag.LastUpdated = DateTime.Now;

            return View(await _partidoNegocio.PartidosBuscar(null, null, torneo.TorneoId, null));
        }

        public IActionResult Index2()
        {
            return View(new Index2Model()
            {
                Fecha = DateTime.Now
            });
        }
    }
}