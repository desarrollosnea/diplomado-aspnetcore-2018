using Core.Datos.Interfaces.Partido;
using Core.Entidades.DB;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Datos.Repositorios.Partido
{
	public class PartidoRepository : IPartidoRepository
	{
		private readonly ProDeContext _context;

		public PartidoRepository(ProDeContext context)
		{
			_context = context;
		}

		//public async Task<List<PartidoCompleto>> BuscarPartido(string palabrasABuscar,
		//	int? faseId, int? torneoId, int? temporadaId)
		//{
		//	var resultado = await _context.PartidoCompleto
		//		.FromSql("exec [partido].[Partido_Buscar] {0},{1},{2},{3}",
		//		palabrasABuscar, faseId, torneoId, temporadaId).ToListAsync();

		//	return resultado;
		//}

		public async Task<dynamic> BuscarPartido(string palabrasABuscar,
			int? faseId, int? torneoId, int? temporadaId)
		{
			var sql = "[partido].[Partido_Buscar]";

			using (var connection = new SqlConnection("Server =.; Database = ProDe; Trusted_Connection = True;"))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@PalabrasABuscar", palabrasABuscar);
				parameters.Add("@FaseId", faseId);
				parameters.Add("@TorneoId", torneoId);
				parameters.Add("@TemporadaId", temporadaId);

				try
				{
					var partido = await SqlMapper.QueryAsync<dynamic>(connection,
						sql,
						parameters,
						commandType:System.Data.CommandType.StoredProcedure);

					
					return partido;


				}
				catch (Exception ex)
				{
					throw ex;
				}

			}
		}
	}
}
