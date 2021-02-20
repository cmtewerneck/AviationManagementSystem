using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IVeiculoServices : IDisposable
    {
        Task<bool> Adicionar(Veiculo veiculo);
        Task<bool> Atualizar(Veiculo veiculo);
        Task<bool> Remover(Guid id);
    }
}
