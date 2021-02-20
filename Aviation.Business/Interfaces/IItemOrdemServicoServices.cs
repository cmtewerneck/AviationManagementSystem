using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IItemOrdemServicoServices : IDisposable
    {
        Task<bool> Adicionar(ItemOrdemServico itemOrdemServico);
        Task<bool> Atualizar(ItemOrdemServico itemOrdemServico);
        Task<bool> Remover(Guid id);
    }
}
