using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prode.Servicios.Models;

namespace Prode.Servicios.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("elemtno: " +id);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(ArchivoPrueba archivoPrueba)
        {
            if (archivoPrueba != null && archivoPrueba.Archivo != null)
            {
                byte[] archivo;
                using (var stream = new MemoryStream())
                {
                    await archivoPrueba.Archivo.CopyToAsync(stream);
                    archivo = stream.ToArray();
                };

                return File(archivo, archivoPrueba.Archivo.ContentType);
            }
            return BadRequest("Ocurrió un problema");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            if (id == 99)
            {
                return NotFound("No se encontró el elemento con id:" + id);
            }
            return Ok("Elemento editar correctamente");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Elemento eliminado correctamente");
        }
    }
}
