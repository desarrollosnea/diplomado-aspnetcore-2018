using ProdeDBFirst.Datos.Interface;
using ProdeDBFirst.Entidades;
using ProdeDBFirst.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Negocio
{
    public class PartidoNegocio: IPartidoNegocio
    {
        private readonly IPartidoRepository _partidoRepository;
        public PartidoNegocio(IPartidoRepository partidoRepository)
        {
            _partidoRepository = partidoRepository;
        }

        public async Task<List<PartidoCompleto>> PartidosBuscar(string PalabrasABuscar, int? FaseId, int? TorneoId, int? TemporadaId)
        {
            return await _partidoRepository.PartidosBuscar(PalabrasABuscar, FaseId, TorneoId, TemporadaId);
        }
    }
}
