using System;
using System.Collections.Generic;

namespace ProdeDBFirst.Entidades
{
    public partial class Equipo
    {
        public Equipo()
        {
            Evento = new HashSet<Evento>();
            PartidoEquipoIdLocalNavigation = new HashSet<Partido>();
            PartidoEquipoIdVisitanteNavigation = new HashSet<Partido>();
        }

        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public EquipoInfo EquipoInfo { get; set; }
        public ICollection<Evento> Evento { get; set; }
        public ICollection<Partido> PartidoEquipoIdLocalNavigation { get; set; }
        public ICollection<Partido> PartidoEquipoIdVisitanteNavigation { get; set; }
    }
}
