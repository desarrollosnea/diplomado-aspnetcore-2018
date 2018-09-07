using ProdeDBFirst.Datos.Base.Interface;
using ProdeDBFirst.Entidades;
using ProdeDBFirst.Negocio.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Negocio.Interfaces
{
    public interface ITorneoNegocio : IGenericBusinessBis<IGenericRepositoryBis<Torneo>, Torneo>
    {
        Task<List<Torneo>> GetAllAsync();
        Task<Torneo> GetById(int torneoId);
    }
}
