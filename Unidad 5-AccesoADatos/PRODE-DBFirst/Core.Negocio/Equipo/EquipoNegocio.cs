using Core.Datos.Interfaces.Equipo;
using Core.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio.Equipo
{
    public class EquipoNegocio : IEquipoNegocio
    {
		public IEquipoRepository Repository;

		public EquipoNegocio(IEquipoRepository repository)
		{
			Repository = repository;
		}


		public async Task<Core.Entidades.DB.Equipo> Details(int equipoId)
		{
			return await Repository.Details(equipoId);
		}
	}
}
