using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Entidades.DB;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Prode.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TemporadaController : ControllerBase
	{
		public List<Torneo> Torneos { get; set; }
		// GET api/values
		[HttpGet]
		public ActionResult<List<Torneo>> Get()
		{
			if (Torneos == null) {
				return new List<Torneo>();
			}
			else
			{
				return Torneos.ToList();
			}
			
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			foreach (var torneo in Torneos)
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
		public ActionResult Post([FromBody] TorneoValidate torneo)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			else
			{
				Torneos.Add(torneo);
				return Ok("Se ha agregado el torneo" + torneo);
			}

		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] TorneoValidate torneo)
		{
			foreach (var item in Torneos)
			{
				if(item.TorneoId == id)
				{
					item.Temporada = torneo.Temporada;
					item.Nombre = torneo.Nombre;
					item.Descripcion = torneo.Descripcion;
				}
			}

			var modificar = Torneos.FirstOrDefault(d => d.TorneoId == id);
			modificar.Temporada = torneo.Temporada;
			modificar.Nombre = torneo.Nombre;

		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			if (id == 0)
			{
					return BadRequest("El id es nulo");
			}
			
			var itemEliminar = Torneos.FirstOrDefault(d => d.TorneoId == id);
			if (itemEliminar == null)
			{
				return BadRequest("No se encontro ese elemento en la lista");

			}
			Torneos.Remove(itemEliminar);
			return Ok("Se elimino su elemento correctamente");
		}


		[HttpGet]
		[Route("getQuery")]
		public IActionResult GetQuery([FromQuery] Torneo torneo)
		{
			return Ok(torneo);
		}


	}
}
