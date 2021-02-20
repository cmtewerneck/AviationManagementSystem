using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAeronaveAbastecimentoServices : IDisposable
    {
        Task<bool> Adicionar(AeronaveAbastecimento aeronaveAbastecimento);
        Task<bool> Atualizar(AeronaveAbastecimento aeronaveAbastecimento);
        Task<bool> Remover(Guid id);
    }
}
