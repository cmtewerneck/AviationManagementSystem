using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IVeiculoMultaServices : IDisposable
    {
        Task<bool> Adicionar(VeiculoMulta veiculoMulta);
        Task<bool> Atualizar(VeiculoMulta veiculoMulta);
        Task<bool> Remover(Guid id);
    }
}
