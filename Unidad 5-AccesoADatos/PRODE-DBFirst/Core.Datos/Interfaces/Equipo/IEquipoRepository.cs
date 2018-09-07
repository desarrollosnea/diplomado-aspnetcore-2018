using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Datos.Interfaces.Equipo
{
    public interface IEquipoRepository
    {
		Task<Core.Entidades.DB.Equipo> Details(int equipoId);

	}
}
