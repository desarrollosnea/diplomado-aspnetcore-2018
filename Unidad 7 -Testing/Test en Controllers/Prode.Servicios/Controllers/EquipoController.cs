using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdeDBFirst.Entidades;
using ProdeDBFirst.Negocio.Interfaces;

namespace Prode.Servicios.Controllers
{
    [Produces("application/json")]
    [Route("api/Equipo")]
    [EnableCors("CorsPolicy")]
    //[Authorize]
    public class EquipoController : Controller
    {
        private readonly IEquipoNegocio _equipoNegocio;

        public EquipoController(IEquipoNegocio equipoNegocio)
        {
            _equipoNegocio = equipoNegocio;
        }


        // GET: api/Equipo
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var equipos = await _equipoNegocio.GetAllAsync();
            return Ok(equipos);
        }

        // GET: api/Equipo/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {

            var equipo = await _equipoNegocio.GetById(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(equipo);
        }

        // POST: api/Equipo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _equipoNegocio.Create(equipo);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
                return Ok("Guardado correctamente");
            }

            return BadRequest("Ocurrió un error al guardar");
        }

        // PUT: api/Equipo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _equipoNegocio.Update(equipo); 
                }
                catch (Exception e)
                {
                    var equipoExiste = await EquipoExists(equipo.EquipoId);
                    if (!equipoExiste)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return BadRequest(e.Message);
                    }
                }
                return Ok("Editado correctamente");
            }
            return BadRequest("Ocurrió un error al editar");
        }

        // DELETE: api/Equipo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var equipo = await _equipoNegocio.GetById(id);
                await _equipoNegocio.Delete(equipo.EquipoId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Eliminado correctamente");
        }

        private async Task<bool> EquipoExists(int id)
        {
            var equipo = await _equipoNegocio.GetById(id);
            return equipo != null;
        }
    }
}
