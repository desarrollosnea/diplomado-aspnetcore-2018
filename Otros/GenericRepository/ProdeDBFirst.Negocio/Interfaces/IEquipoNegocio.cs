
using ProdeDBFirst.Entidades;
using ProdeDBFirst.Negocio.Base.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Negocio.Interfaces
{
    public interface IEquipoNegocio: IGenericBusiness<Equipo>
    {
        Task<Equipo> GetById(int equipoId);
        Task<bool> Delete(int equipoId);
    }
}
