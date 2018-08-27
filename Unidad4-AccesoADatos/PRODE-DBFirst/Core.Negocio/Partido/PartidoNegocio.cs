using Core.Datos.Interfaces.Partido;
using Core.Entidades.DB;
using Core.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio.Partido
{
	public class PartidoNegocio : IPartidoNegocio
	{
		public IPartidoRepository Repository;

		public PartidoNegocio(IPartidoRepository repository)
		{
			Repository = repository;
		}

		public async Task<dynamic> BuscarPartido(string palabrasABuscar, 
			int? faseId, int? torneoId, int? temporadaId)
		{
			return await Repository.BuscarPartido(palabrasABuscar,
				faseId, torneoId, temporadaId);
		}
	}
}
