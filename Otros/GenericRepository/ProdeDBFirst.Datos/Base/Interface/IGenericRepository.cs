using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Datos.Base.Interface
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        Task<List<TEntity>> GetAllAsync();

        Task<bool> Create(TEntity entity);

        Task<bool> Update(TEntity entity);

        Task<bool> Detele(TEntity entity);
    }
}
