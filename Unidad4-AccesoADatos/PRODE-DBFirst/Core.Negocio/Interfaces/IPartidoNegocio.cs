using Core.Entidades.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio.Interfaces
{
    public interface IPartidoNegocio
    {
		Task<dynamic> BuscarPartido(string palabrasABuscar,
			int? faseId, int? torneoId, int? temporadaId);
	}
}
