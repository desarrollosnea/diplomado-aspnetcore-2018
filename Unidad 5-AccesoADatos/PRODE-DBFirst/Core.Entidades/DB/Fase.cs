using System;
using System.Collections.Generic;

namespace Core.Entidades.DB
{
    public partial class Fase
    {
        public Fase()
        {
            Partido = new HashSet<Partido>();
        }

        public int FaseId { get; set; }
        public int TorneoId { get; set; }
        public string Nombre { get; set; }

        public Torneo Torneo { get; set; }
        public ICollection<Partido> Partido { get; set; }
    }
}
