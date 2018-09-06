using System;
using System.Collections.Generic;

namespace MvcJquery.Models
{
    public partial class PartidoCompleto
    {
        public int PartidoCompletoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
        public string Fase { get; set; }
        public string Torneo { get; set; }
        public string Temporada { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
        public int TarjetaAmarillaLocal { get; set; }
        public int TarjetaAmarillaVisitante { get; set; }
        public int TarjetaRojaLocal { get; set; }
        public int TarjetaRojaVisitante { get; set; }
    }
}
