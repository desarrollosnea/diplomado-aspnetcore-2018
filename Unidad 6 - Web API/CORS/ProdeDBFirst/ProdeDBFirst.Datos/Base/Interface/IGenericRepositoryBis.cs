using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Datos.Base.Interface
{
    public interface IGenericRepositoryBis<TEntity> where TEntity: class
    {
        Task<List<TEntity>> GetAllAsync();
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
