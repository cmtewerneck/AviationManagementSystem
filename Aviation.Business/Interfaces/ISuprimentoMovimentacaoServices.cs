using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ISuprimentoMovimentacaoServices : IDisposable
    {
        Task<bool> Adicionar(SuprimentoMovimentacao suprimentoMovimentacao);
        Task<bool> Atualizar(SuprimentoMovimentacao suprimentoMovimentacao);
        Task<bool> Remover(Guid id);
    }
}
