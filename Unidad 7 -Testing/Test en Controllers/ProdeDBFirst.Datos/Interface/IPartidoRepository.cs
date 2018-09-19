using ProdeDBFirst.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Datos.Interface
{
    public interface IPartidoRepository
    {
        Task<List<PartidoCompleto>> PartidosBuscar(string PalabrasABuscar, int? FaseId, int? TorneoId, int? TemporadaId);
    }
}
