using System;
using System.Collections.Generic;

namespace Core.Entidades.DB
{
    public partial class Temporada
    {
        public Temporada()
        {
            Torneo = new HashSet<Torneo>();
        }

        public int TemporadaId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public ICollection<Torneo> Torneo { get; set; }
    }
}
