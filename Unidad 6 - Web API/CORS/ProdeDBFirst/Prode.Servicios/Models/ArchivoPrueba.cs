using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prode.Servicios.Models
{
    public class ArchivoPrueba
    {
        public string Propietario { get; set; }
        public int Numero { get; set; }
        public IFormFile Archivo { get; set; }
    }
}
