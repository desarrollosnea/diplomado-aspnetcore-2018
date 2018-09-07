using Microsoft.EntityFrameworkCore;
using ProdeDBFirst.Datos.Base.Interface;
using ProdeDBFirst.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Datos.Base
{
    public class GenericRepositoryBis<TEntity> : IGenericRepositoryBis<TEntity> where TEntity : class
    {
        public readonly ProDeContext _context;
        public GenericRepositoryBis(ProDeContext prodeContext)
        {
            _context = prodeContext;
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
             _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
             _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
