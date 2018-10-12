using Microsoft.EntityFrameworkCore;
using ProdeDBFirst.Datos.Interface;
using ProdeDBFirst.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Datos
{
    public class PartidoRepository: IPartidoRepository
    {
        private readonly ProDeContext _dbContext;
        public PartidoRepository(ProDeContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<PartidoCompleto>> PartidosBuscar(string PalabrasABuscar, int? FaseId, int? TorneoId, int? TemporadaId)
        {
            try
            {
                var collection = await _dbContext.PartidoCompleto.FromSql("EXECUTE [partido].[Partido_Buscar] {0},{1},{2},{3}", 
                    PalabrasABuscar, FaseId, TorneoId, TemporadaId).ToListAsync();

                return collection;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

    }
}
