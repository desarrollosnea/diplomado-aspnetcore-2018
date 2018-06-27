using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Prode.App.Entidades.Enumeraciones
{
	public enum ResultadoEnum : byte
	{
		[Description("Empate")]
		empate = 0,
		[Description("Ganó")]
		gano = 1,
		[Description("Perdio")]
		perdio = 2,
	}
}


