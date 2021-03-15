using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ISuprimentoRepository : IRepository<Suprimento>
    {
        Task<Suprimento> ObterSuprimentoMovimentacao(Guid id);

        Task<IEnumerable<Suprimento>> ObterSuprimentosMovimentacoes();

        Task<Suprimento> ObterSuprimentoMovimentacoes(Guid id);
    }
}