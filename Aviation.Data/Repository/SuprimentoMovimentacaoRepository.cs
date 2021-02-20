using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using System;
using System.Collections.Generic;
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
    }
}
