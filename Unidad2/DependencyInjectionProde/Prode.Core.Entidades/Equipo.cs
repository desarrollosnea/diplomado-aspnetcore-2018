using Prode.Core.Entidades.Interfaces;
using System;

namespace Prode.Core.Entidades
{
    public class Equipo : IEquipo
    {
        public string Nombre { get ; set ; }
        public string Abreviatura { get; set; }
    }
}
