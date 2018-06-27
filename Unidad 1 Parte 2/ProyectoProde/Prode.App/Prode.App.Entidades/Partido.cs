using System;
using System.Collections.Generic;
using System.Text;

namespace Prode.App.Entidades
{
	public class Partido
	{
		public Equipo EquipoLocal { get; set; }
		public Equipo EquipoVisitante { get; set; }
		public int GolesLocal { get; set; }
		public int GolesVisitante { get; set; }
		public DateTime Fecha { get; set; }
		public string Lugar { get; set; }

		public string InformarResultado
		{
			get
			{
				var resultado = "";
				if (GolesVisitante > GolesLocal)
				{
					resultado = "Ganó " + EquipoVisitante.Nombre;
				}
				else if (GolesVisitante < GolesLocal)
				{
					resultado = "Ganó " + EquipoLocal.Nombre;
				}
				else
				{
					resultado = "Empate";
				}
				return resultado;
			}
			
		}
	}
}
