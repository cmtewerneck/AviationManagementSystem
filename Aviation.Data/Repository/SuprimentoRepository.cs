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
    public class SuprimentoRepository : Repository<Suprimento>, ISuprimentoRepository
    {
        public SuprimentoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<Suprimento> ObterSuprimentoMovimentacao(Guid id)
        {
            return await Db.Suprimentos.AsNoTracking()
                .Include(c => c.SuprimentosMovimentacoes)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Suprimento>> ObterSuprimentosMovimentacoes()
        {
            return await Db.Suprimentos.AsNoTracking()
                .OrderBy(p => p.Codigo)
                .ToListAsync();
        }
    }
}
