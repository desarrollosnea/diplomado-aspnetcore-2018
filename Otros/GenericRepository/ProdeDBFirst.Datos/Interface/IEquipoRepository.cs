
using ProdeDBFirst.Datos.Base.Interface;
using ProdeDBFirst.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Datos.Interface
{
    public interface IEquipoRepository: IGenericRepository<Equipo>
    {
        Task<Equipo> GetById(int equipoId);
        Task<bool> Delete(int equipoId);
    }
}
