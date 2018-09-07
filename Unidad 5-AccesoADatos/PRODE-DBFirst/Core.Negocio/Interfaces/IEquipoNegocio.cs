using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocio.Interfaces
{
    public interface IEquipoNegocio
    {
		Task<Core.Entidades.DB.Equipo> Details(int equipoId);
	}
}
