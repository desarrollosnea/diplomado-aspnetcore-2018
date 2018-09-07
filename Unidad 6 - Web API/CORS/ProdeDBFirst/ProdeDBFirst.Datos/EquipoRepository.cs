using Microsoft.EntityFrameworkCore;
using ProdeDBFirst.Datos.Base;
using ProdeDBFirst.Datos.Interface;
using ProdeDBFirst.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Datos
{
    public class EquipoRepository: GenericRepository<Equipo>, IEquipoRepository
    {
        public EquipoRepository(ProDeContext dbContext): base(dbContext)
        {

        }

        public async Task<Equipo> GetById(int equipoId)
        {
            return await _dbContext.Equipo.FirstOrDefaultAsync(e => e.EquipoId == equipoId);
        }

        //public async Task<List<Equipo>> GetAllAsync()
        //{
        //    return await GetAll()
        //        .ToListAsync();
        //}

        public async Task<bool> Delete(int equipoId)
        {
            try
            {
                //var equipoCompleto = await _dbContext.Equipo.Include(b => b.EquipoInfo).FirstOrDefaultAsync(e => e.EquipoId == equipoId);

                //_dbContext.Remove(equipoCompleto);
                //await _dbContext.SaveChangesAsync();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@EquipoId", equipoId));
                
                var result = await _dbContext.Database.ExecuteSqlCommandAsync("[equipo].[Equipo_Eliminar] @EquipoId", sqlParameters.ToArray());
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception e)
            {
                //log error
                return false;
            }
            
        }
    }
}
