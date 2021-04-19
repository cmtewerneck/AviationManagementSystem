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
    public class AeronaveDiretrizRepository : Repository<AeronaveDiretriz>, IAeronaveDiretrizRepository
    {
        public AeronaveDiretrizRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<AeronaveDiretriz> ObterDiretrizAeronave(Guid id)
        {
            return await Db.AeronavesDiretrizes
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<AeronaveDiretriz>> ObterDiretrizesAeronaves()
        {
            return await Db.AeronavesDiretrizes
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .OrderBy(p => p.Aeronave)
                .ToListAsync();
        }

        public async Task<IEnumerable<AeronaveDiretriz>> ObterDiretrizesPorAeronave(Guid aeronaveId)
        {
            return await Buscar(p => p.AeronaveId == aeronaveId);
        }
    }
}
