using Core.Entidades.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Datos.Interfaces.Partido
{
    public interface IPartidoRepository
    {
		Task<dynamic> BuscarPartido(string palabrasABuscar, 
			int? faseId, int? torneoId, int? temporadaId);
	}
}
