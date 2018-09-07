using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaSwaggerController : ControllerBase
    {
        // GET api/values
        /// <summary>
        /// Muestra mis valores
        /// </summary>
        /// <response code="200">Enviaste bien el valor</response>
        /// <response code="400">Valor erroneo</response>
        /// <returns><string>String</string></returns>
        [HttpGet]
       
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// Muestra los resultados de mi partido
        /// </summary>
        /// <remarks>
        /// Estamos haciendo una prueba de si este tag te muestra una descripcion mas larga de que hace el post
        /// </remarks>
        /// <param type="int" name="value"></param>
        [HttpPost]
        [Produces("application/json", Type = typeof(value2))]
        public void Post([FromBody] Value value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
