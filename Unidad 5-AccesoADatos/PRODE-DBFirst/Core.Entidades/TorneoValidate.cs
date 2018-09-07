using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entidades.DB
{
	public partial class TorneoValidate : Torneo
	{
		public TorneoValidate()
		{
			Fase = new HashSet<Fase>();
		}


		public int TorneoId { get; set; }
		[Range(0, 10)]
		public int TemporadaId { get; set; }
		[Required]
		[StringLength(10)]
		public string Nombre { get; set; }
		[StringLength(100)]
		[MinLength(3)]
		public string Descripcion { get; set; }

		public Temporada Temporada { get; set; }
		public ICollection<Fase> Fase { get; set; }
		[EmailAddress]
		public string Email { get; set; }
	}
}
