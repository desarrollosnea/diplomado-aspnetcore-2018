using Core.Datos.Interfaces.Equipo;
using Core.Entidades.DB;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Core.Datos.Repositorios.Equipo
{
    public class EquipoRepository: IEquipoRepository
    {
		private readonly ProDeContext _context;

		public EquipoRepository(ProDeContext context)
		{
			_context = context;
		}

		//public async Task<Core.Entidades.DB.Equipo> Details(int equipoId)
		//{
		//	var equipo = await _context.Equipo.Include(e=>e.EquipoInfo)
		//		.FirstOrDefaultAsync(m => m.EquipoId == equipoId);

		//	return equipo;
		//}

		//public async Task<Core.Entidades.DB.Equipo> Details(int equipoId)
		//{
		//	var sql = "Select * From equipo.Equipo where EquipoId = @EquipoId";

		//	using (var connection = new SqlConnection("Server =.; Database = ProDe; Trusted_Connection = True;"))
		//	{
		//		var param = new DynamicParameters();
		//		param.Add("@EquipoId", equipoId);

		//		try
		//		{
		//			var equipo = await SqlMapper.QueryFirstAsync<Core.Entidades.DB.Equipo>(connection, 
		//				sql, 
		//				param);

		//			return equipo;

		//		}catch(Exception ex)
		//		{
		//			throw ex;
		//		}

		//	}

		//}

		public async Task<Core.Entidades.DB.Equipo> Details(int equipoId)
		{
			var sql = "Select * From equipo.Equipo where EquipoId = @EquipoId";

			using (var connection = new SqlConnection("Server =.; Database = ProDe; Trusted_Connection = True;"))
			{
				
				try
				{
					var equipo = await SqlMapper.QueryFirstAsync<Core.Entidades.DB.Equipo>(connection,
						sql,
						new {EquipoId = equipoId });

					return equipo;

				}
				catch (Exception ex)
				{
					throw ex;
				}

			}

		}

	}
}
