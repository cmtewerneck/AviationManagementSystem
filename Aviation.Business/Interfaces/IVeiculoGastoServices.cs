using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IVeiculoGastoServices : IDisposable
    {
        Task<bool> Adicionar(VeiculoGasto veiculoGasto);
        Task<bool> Atualizar(VeiculoGasto veiculoGasto);
        Task<bool> Remover(Guid id);
    }
}
