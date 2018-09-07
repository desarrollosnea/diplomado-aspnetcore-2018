using System;
using System.Collections.Generic;
using System.Text;

namespace ProdeDBFirst.Negocio.Base.Interfaces
{
    public interface IGenericBusinessBis<TRepo, TEntity> : IBaseBusiness<TRepo> where TRepo: class where TEntity: class
    {
    }
}
