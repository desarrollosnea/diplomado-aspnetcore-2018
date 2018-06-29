using Prode.Core.Entidades.Interfaces;
using System;

namespace Prode.Core.Entidades
{
    public class Formateador : IFormateador
    {
        private string _id;

        public Formateador()
        {
            _id = Guid.NewGuid().ToString();
        }

        public string NombreCompleto(IEquipo equipo)
        {
            return $"Nombre completo {equipo.Nombre} ({equipo.Abreviatura}) {_id}";
        }
    }
}
