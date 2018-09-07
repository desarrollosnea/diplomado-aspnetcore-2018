using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Negocio.Base.Interfaces
{
    public interface IGenericBusiness<TEntity> /*: IBaseBusiness<TRepo>*/ where TEntity : class
    {
        //IQueryable<TEntity> GetAll();

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}
