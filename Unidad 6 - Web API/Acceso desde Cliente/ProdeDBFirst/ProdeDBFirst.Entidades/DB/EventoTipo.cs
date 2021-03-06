﻿using System;
using System.Collections.Generic;

namespace ProdeDBFirst.Entidades
{
    public partial class EventoTipo
    {
        public EventoTipo()
        {
            Evento = new HashSet<Evento>();
        }

        public int EventoTipoId { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }

        public ICollection<Evento> Evento { get; set; }
    }
}
