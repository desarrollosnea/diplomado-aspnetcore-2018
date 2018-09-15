using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using swagger;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET api/values
  
        [HttpGet]
        public IList<string> Get()
        {
            ApidePruebaconSwagger api = new ApidePruebaconSwagger
            {
                BaseUri = new Uri("http://localhost:57910")
            };
            return api.ApiPruebaSwaggerGet();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IList<string> Get(int id)
        {
            ApidePruebaconSwagger api = new ApidePruebaconSwagger
            {
                BaseUri = new Uri("http://localhost:57910")
            };
            return api.ApiPruebaSwaggerGet();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
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
