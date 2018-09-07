using ProdeDBFirst.Datos.Base.Interface;
using ProdeDBFirst.Negocio.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdeDBFirst.Negocio.Base
{
    public class GenericBusinessBis<TEntity> : IGenericBusinessBis<IGenericRepositoryBis<TEntity>, TEntity> where TEntity: class
    {
        public IGenericRepositoryBis<TEntity> Repository { get; set; }
        public GenericBusinessBis(IGenericRepositoryBis<TEntity> genericRepository)
        {
            Repository = genericRepository;
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

        ~GenericBusinessBis()
        {
            Dispose(false);
        }

        #endregion
    }
}
