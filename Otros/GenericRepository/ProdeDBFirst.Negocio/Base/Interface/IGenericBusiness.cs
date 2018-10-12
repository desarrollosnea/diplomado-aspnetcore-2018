using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Negocio.Base.Interface
{
    public interface IGenericBusiness<TEntity> where TEntity: class
    {
        Task<List<TEntity>> GetAllAsync();

        Task<bool> Create(TEntity entity);

        Task<bool> Update(TEntity entity);

        Task<bool> Detele(TEntity entity);
    }
}
