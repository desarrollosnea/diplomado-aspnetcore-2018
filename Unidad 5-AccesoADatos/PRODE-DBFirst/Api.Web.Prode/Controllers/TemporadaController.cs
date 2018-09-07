using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Entidades.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Api.Web.Prode.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TemporadaController : ControllerBase
	{
		public IMemoryCache _cache { get; set; }
		public TemporadaController(IMemoryCache cache)
		{
			_cache = cache;
			_cache.CreateEntry("TorneosPrueba");
		}
		
		
		// GET api/values
		[HttpGet]
		public ActionResult<List<Torneo>> Get()
		{
			var Torneos = new List<Torneo>();
			if (Torneos == null) {
				return new List<Torneo>();
			}
			else
			{
				var cacheEntry = _cache.GetOrCreate("Torneos", Entry =>
				{
					return Torneos;

				});
				string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(Torneos);

				return cacheEntry.ToList();
			}
			
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			var Torneos = new List<Torneo>();
			var cacheEntry = _cache.GetOrCreate("Torneos", Entry =>
			{
				return Torneos;

			});
			foreach (var torneo in cacheEntry)
			{
				if(torneo.TorneoId == id)
				{
					return Ok("El torneo del id buscado es" + torneo.Nombre);
				}
				else
				{
					return BadRequest("No se encontro el torneo buscado con el id:" + id);
				}
			}
			
			return BadRequest("No tenemos ningun torneo asociado");
		}

		// POST api/values
		[HttpPost]
		public ActionResult Post([FromBody] Torneo torneo)
		{
		
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			else
			{
				var Torneos = new List<Torneo>();
				
				
				var cacheEntry = _cache.GetOrCreate("Torneos", Entry =>
				{
					return Torneos;
				});
				cacheEntry.Add(torneo);
				_cache.Set("Torneos", cacheEntry);
				string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(cacheEntry);
				return Ok("Se ha agregado el torneo" + jsonString);
			}

		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] Torneo torneo)
		{
			var Torneos = new List<Torneo>();
			var cacheEntry = _cache.GetOrCreate("Torneos", Entry =>
			{
				return Torneos;

			});
			foreach (var item in cacheEntry)
			{
				if(item.TorneoId == id)
				{
					item.Temporada = torneo.Temporada;
					item.Nombre = torneo.Nombre;
					item.Descripcion = torneo.Descripcion;
				}
			}
			_cache.Set("Torneos", cacheEntry);
			//var modificar = Torneos.FirstOrDefault(d => d.TorneoId == id);
			//modificar.Temporada = torneo.Temporada;
			//modificar.Nombre = torneo.Nombre;

		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			if (id == 0)
			{
					return BadRequest("El id es nulo");
			}
			var Torneos = new List<Torneo>();
			var cacheEntry = _cache.GetOrCreate("Torneos", Entry =>
			{
				return Torneos;

			});

			var itemEliminar = cacheEntry.FirstOrDefault(d => d.TorneoId == id);
			if (itemEliminar == null)
			{
				return BadRequest("No se encontro ese elemento en la lista");

			}
			cacheEntry.Remove(itemEliminar);

			_cache.Set("Torneos", cacheEntry);
			return Ok("Se elimino su elemento correctamente");
		}


		[HttpGet]
		[Route("getQuery")]
		public IActionResult GetQuery([FromQuery] Torneo torneo)
		{
			return Ok(torneo);
		}
		[HttpPost]
		[Route("archivo")]
		public ActionResult Archivo (IFormFile archivo)
		{
			if(archivo == null)
			{
				return BadRequest("El id es nulo");
			}
			else
			{
				return Ok("Muy bien!!!!");
			}
		}
	}
}
