
using ProdeDBFirst.Datos.Base.Interface;
using ProdeDBFirst.Negocio.Base.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Negocio.Base
{
    public class GenericBusiness<TEntity> : IGenericBusiness<TEntity> where TEntity : class
    {
        public IGenericRepository<TEntity> _genericRepository { get; set; }
        public GenericBusiness(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<bool> Create(TEntity entity)
        {
            return await _genericRepository.Create(entity);
        }

        public async Task<bool> Detele(TEntity entity)
        {
            return await _genericRepository.Detele(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<bool> Update(TEntity entity)
        {
            return await _genericRepository.Update(entity);
        }
    }
}
