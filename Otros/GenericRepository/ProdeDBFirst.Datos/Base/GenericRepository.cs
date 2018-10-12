using Microsoft.EntityFrameworkCore;
using ProdeDBFirst.Datos.Base.Interface;
using ProdeDBFirst.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Datos.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public ProDeContext _context { get; set; }
        public GenericRepository(ProDeContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<bool> Create(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                //log e 
                return false;
            }
            
        }

        public async Task<bool> Detele(TEntity entity)
        {
            try
            {
                 _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                //log e 
                return false;
            }
        }

        public async Task<bool> Update(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                //log e 
                return false;
            }
        }
    }
}
