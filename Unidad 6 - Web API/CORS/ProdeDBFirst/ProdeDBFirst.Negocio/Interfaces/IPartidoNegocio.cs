using ProdeDBFirst.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Negocio.Interfaces
{
    public interface IPartidoNegocio
    {
        Task<List<PartidoCompleto>> PartidosBuscar(string PalabrasABuscar, int? FaseId, int? TorneoId, int? TemporadaId);
    }
}
