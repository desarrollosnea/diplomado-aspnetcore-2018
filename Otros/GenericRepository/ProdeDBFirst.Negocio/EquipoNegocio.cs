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
    public class EquipoNegocio: GenericBusiness<Equipo>, IEquipoNegocio
    {
        private readonly IEquipoRepository _repository;

        public EquipoNegocio(IEquipoRepository repository): base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int equipoId)
        {
            return await _repository.Delete(equipoId);
        }

        public async Task<Equipo> GetById(int equipoId)
        {
            return await _repository.GetById(equipoId);
        }
    }
}
