using System;
using System.Collections.Generic;

namespace ProdeDBFirst.Entidades
{
    public partial class EquipoInfo
    {
        public int EquipoId { get; set; }
        public string Web { get; set; }
        public string IconoUrl { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }

        public Equipo Equipo { get; set; }
    }
}
