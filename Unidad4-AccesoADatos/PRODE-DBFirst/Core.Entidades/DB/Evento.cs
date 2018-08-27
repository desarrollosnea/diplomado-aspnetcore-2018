using System;
using System.Collections.Generic;

namespace Core.Entidades.DB
{
    public partial class Evento
    {
        public long EventoId { get; set; }
        public int PartidoId { get; set; }
        public int EventoTipoId { get; set; }
        public int? EquipoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public Equipo Equipo { get; set; }
        public EventoTipo EventoTipo { get; set; }
        public Partido Partido { get; set; }
    }
}
