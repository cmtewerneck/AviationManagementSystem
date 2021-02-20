using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IOrdemServicoServices : IDisposable
    {
        Task<bool> Adicionar(OrdemServico ordemServico);
        Task<bool> Atualizar(OrdemServico ordemServico);
        Task<bool> Remover(Guid id);
    }
}
