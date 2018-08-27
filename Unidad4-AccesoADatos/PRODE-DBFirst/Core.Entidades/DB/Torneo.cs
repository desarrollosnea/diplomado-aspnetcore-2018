using System;
using System.Collections.Generic;

namespace Core.Entidades.DB
{
    public partial class Torneo
    {
        public Torneo()
        {
            Fase = new HashSet<Fase>();
        }

        public int TorneoId { get; set; }
        public int TemporadaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Temporada Temporada { get; set; }
        public ICollection<Fase> Fase { get; set; }
    }
}
