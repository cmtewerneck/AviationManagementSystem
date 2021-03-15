using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ISuprimentoMovimentacaoRepository : IRepository<SuprimentoMovimentacao>
    {
        Task<IEnumerable<SuprimentoMovimentacao>> ObterMovimentacoesPorSuprimento(Guid suprimentoId);

        Task<IEnumerable<SuprimentoMovimentacao>> ObterMovimentacoesSuprimentos();
    }
}