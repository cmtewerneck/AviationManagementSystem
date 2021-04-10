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
    public class EscalaRepository : Repository<Escala>, IEscalaRepository
    {
        public EscalaRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<Escala>> ObterEscalasTripulantes()
        {
            return await Db.Escalas
                .AsNoTracking()
                .Include(f => f.Tripulante)
                .OrderBy(p => p.Data).ToListAsync();
        }

        public async Task<Escala> ObterEscalaTripulante(Guid id)
        {
            return await Db.Escalas
                .Include(c => c.Tripulante)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
