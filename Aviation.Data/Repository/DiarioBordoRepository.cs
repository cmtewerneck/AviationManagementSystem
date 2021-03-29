using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Data.Repository
{
    public class DiarioBordoRepository : Repository<DiarioBordo>, IDiarioBordoRepository
    {
        public DiarioBordoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<DiarioBordo>> ObterDiariosAeronavesColaboradores()
        {
            return await Db.DiariosBordo.AsNoTracking()
                .Include(f => f.Aeronave)
                .Include(f => f.Comandante)
                .Include(f => f.Copiloto)
                .Include(f => f.MecanicoResponsavel)
                .OrderBy(p => p.Data).ToListAsync();
        }

        public async Task<IEnumerable<DiarioBordo>> ObterDiariosAeronaves()
        {
            return await Db.DiariosBordo
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .OrderBy(p => p.Data).ToListAsync();
        }

        public async Task<DiarioBordo> ObterDiarioAeronaveColaboradores(Guid id)
        {
            return await Db.DiariosBordo
                .Include(c => c.Aeronave)
                .Include(c => c.Comandante)
                .Include(c => c.Copiloto)
                .Include(c => c.MecanicoResponsavel)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
