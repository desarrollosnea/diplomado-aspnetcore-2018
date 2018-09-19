using Microsoft.EntityFrameworkCore;
using ProdeDBFirst.Datos.Base;
using ProdeDBFirst.Datos.Base.Interface;
using ProdeDBFirst.Datos.Interface;
using ProdeDBFirst.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Datos
{
    public class TorneoRepository: GenericRepositoryBis<Torneo>,ITorneoRepository
    {
        public TorneoRepository(ProDeContext dbContext):base(dbContext)
        {
        }
        
        public async Task<Torneo> GetById(int torneoId)
        {
            return await _context.Torneo.FirstOrDefaultAsync(t=>t.TorneoId == torneoId);
        }
    }
}
