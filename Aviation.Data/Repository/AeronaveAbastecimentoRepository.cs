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
    public class AeronaveAbastecimentoRepository : Repository<AeronaveAbastecimento>, IAeronaveAbastecimentoRepository
    {
        public AeronaveAbastecimentoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<AeronaveAbastecimento> ObterAbastecimentoAeronave(Guid id)
        {
            return await Db.AeronavesAbastecimentos.AsNoTracking().Include(f => f.Aeronave)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<AeronaveAbastecimento>> ObterAbastecimentosAeronaves()
        {
            return await Db.AeronavesAbastecimentos.AsNoTracking().Include(f => f.Aeronave)
                .OrderBy(p => p.Data).ToListAsync();
        }

        public async Task<IEnumerable<AeronaveAbastecimento>> ObterAbastecimentosPorAeronave(Guid aeronaveId)
        {
            return await Buscar(p => p.AeronaveId == aeronaveId);
        }
    }
}
