using ProdeDBFirst.Datos.Base.Interface;
using ProdeDBFirst.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Datos.Interface
{
    public interface ITorneoRepository : IGenericRepositoryBis<Torneo>
    {
        Task<Torneo> GetById(int torneoId);
    }
}
