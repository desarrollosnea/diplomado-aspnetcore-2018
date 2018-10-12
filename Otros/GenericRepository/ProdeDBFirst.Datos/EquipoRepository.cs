using Microsoft.EntityFrameworkCore;
using ProdeDBFirst.Datos.Base;
using ProdeDBFirst.Datos.Interface;
using ProdeDBFirst.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Datos
{
    public class EquipoRepository: GenericRepository<Equipo>, IEquipoRepository
    {
        public EquipoRepository(ProDeContext dbContext): base(dbContext)
        {
        }

        public async Task<Equipo> GetById(int equipoId)
        {
            return await _context.Equipo.Include(e=>e.EquipoInfo).FirstOrDefaultAsync(e => e.EquipoId == equipoId);
        }

        public async Task<bool> Delete(int equipoId)
        {
            try
            {
                //var equipoCompleto = await _context.Equipo.Include(b => b.EquipoInfo).FirstOrDefaultAsync(e => e.EquipoId == equipoId);
                var equipoCompleto = await _context.Equipo.FirstOrDefaultAsync(e => e.EquipoId == equipoId);
                _context.Remove(equipoCompleto);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception e)
            {
                //log error
                return false;
            }
        }
    }
}
