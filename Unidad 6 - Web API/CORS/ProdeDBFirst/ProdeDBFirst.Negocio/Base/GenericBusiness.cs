using ProdeDBFirst.Datos.Base.Interface;
using ProdeDBFirst.Negocio.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Negocio.Base
{
    public class GenericBusiness<TEntity> : IGenericBusiness<TEntity>
        where TEntity : class
    {
        public IGenericRepository<TEntity> Repository { get; set; }
        public GenericBusiness(IGenericRepository<TEntity> genericRepository)
        {
            Repository = genericRepository;
        }

        public async Task Create(TEntity entity)
        {
            await Repository.Create(entity);
        }

        public async Task Delete(TEntity entity)
        {
            await Repository.Delete(entity);
        }

        public async Task Update(TEntity entity)
        {
            await Repository.Update(entity);
        }

        #region IDisposable

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Repository != null)
                    {
                        //_genericRepository.Dispose();
                        Repository = null;
                    }
                }
            }
            disposed = true;
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~GenericBusiness()
        {
            Dispose(false);
        }

        #endregion
    }
}
