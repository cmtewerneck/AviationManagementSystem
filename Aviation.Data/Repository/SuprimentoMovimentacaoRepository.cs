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
    public class SuprimentoMovimentacaoRepository : Repository<SuprimentoMovimentacao>, ISuprimentoMovimentacaoRepository
    {
        public SuprimentoMovimentacaoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<SuprimentoMovimentacao>> ObterMovimentacoesPorSuprimento(Guid suprimentoId)
        {
            return await Buscar(p => p.ItemId == suprimentoId);
        }

        public async Task<IEnumerable<SuprimentoMovimentacao>> ObterMovimentacoesSuprimentos()
        {
            return await Db.SuprimentosMovimentacoes.AsNoTracking().Include(f => f.Item)
                .OrderBy(p => p.Data).ToListAsync();
        }
    }
}
