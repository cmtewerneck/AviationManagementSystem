using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Data.Repository
{
    public class VooAgendadoRepository : Repository<VooAgendado>, IVooAgendadoRepository
    {
        public VooAgendadoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<VooAgendado> ObterVooAgendadoAeronave(Guid id)
        {
            return await Db.VoosAgendados.AsNoTracking()
                .Include(f => f.Aeronave)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<VooAgendado>> ObterVoosAgendadosAeronaves()
        {
            return await Db.VoosAgendados.AsNoTracking()
                .Include(f => f.Aeronave)
                .OrderBy(p => p.Start)
                .ToListAsync();
        }

        public async Task<IEnumerable<VooAgendado>> ObterVoosAgendadosAeronavesCategorias()
        {
            return await Db.VoosAgendados
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .Include(f => f.Categoria)
                .OrderBy(p => p.Start)
                .ToListAsync();
        }

        public async Task<IEnumerable<VooAgendado>> ObterVoosAgendadosPorAeronave(Guid aeronaveId)
        {
            return await Buscar(p => p.AeronaveId == aeronaveId);
        }
    }
}
