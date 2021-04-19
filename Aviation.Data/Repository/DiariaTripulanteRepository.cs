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
    public class DiariaTripulanteRepository : Repository<DiariaTripulante>, IDiariaTripulanteRepository
    {
        public DiariaTripulanteRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<DiariaTripulante>> ObterDiariasTripulantes()
        {
            return await Db.DiariasTripulante
                .AsNoTracking()
                .Include(f => f.Tripulante)
                .OrderBy(p => p.DataInicio)
                .ToListAsync();
        }

        public async Task<DiariaTripulante> ObterDiariaTripulante(Guid id)
        {
            return await Db.DiariasTripulante
                .Include(c => c.Tripulante)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
