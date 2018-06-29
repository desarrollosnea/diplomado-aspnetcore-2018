using Prode.Core.Entidades.Interfaces;
using System;

namespace Prode.Core.Formateadores
{
    public class SuperCoolFormateador : IFormateador
    {
        public string NombreCompleto(IEquipo equipo)
        {
            return $"***** {equipo.Nombre} ******";
        }
    }
}
