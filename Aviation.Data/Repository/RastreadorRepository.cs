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
    public class RastreadorRepository : Repository<Rastreador>, IRastreadorRepository
    {
        public RastreadorRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<Rastreador>> ObterRastreadoresAeronaves()
        {
            return await Db.Rastreadores
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .OrderBy(p => p.Codigo)
                .ToListAsync();
        }

        public async Task<Rastreador> ObterRastreadorAeronave(Guid id)
        {
            return await Db.Rastreadores
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
