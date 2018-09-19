using ProdeDBFirst.Datos.Base.Interface;
using ProdeDBFirst.Datos.Interface;
using ProdeDBFirst.Entidades;
using ProdeDBFirst.Negocio.Base;
using ProdeDBFirst.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Negocio
{
    public class TorneoNegocio: GenericBusinessBis<Torneo>, ITorneoNegocio
    {
        private readonly ITorneoRepository _repository;
        public TorneoNegocio(ITorneoRepository torneoRepository): base(torneoRepository)
        {
            _repository = torneoRepository;
        }

        public async Task<List<Torneo>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Torneo> GetById(int torneoId)
        {
            return await _repository.GetById(torneoId);
        }
    }
}
