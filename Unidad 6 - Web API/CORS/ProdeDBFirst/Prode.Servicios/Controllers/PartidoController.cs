using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdeDBFirst.Negocio.Interfaces;

namespace Prode.Servicios.Controllers
{
    [Produces("application/json")]
    [Route("api/Partido")]
    public class PartidoController : Controller
    {

        public IPartidoNegocio PartidoNegocio { get; set; }
        public PartidoController(IPartidoNegocio partidoNegocio)
        {
            PartidoNegocio = partidoNegocio;
        }

        // GET: api/Partido
        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var partidos = await PartidoNegocio.PartidosBuscar(null, null, null, null);
            return Ok(partidos);
        }
        
        
    }
}
