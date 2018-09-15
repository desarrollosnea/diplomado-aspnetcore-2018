using Microsoft.EntityFrameworkCore;
using ProdeDBFirst.Datos.Base.Interface;
using ProdeDBFirst.Datos.Interface;
using ProdeDBFirst.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Datos.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class//, <span class="pl-en">IEntity</span>
    {
        public readonly ProDeContext _dbContext;

        public GenericRepository(ProDeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
