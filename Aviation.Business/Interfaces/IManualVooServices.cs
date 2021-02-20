using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IManualVooServices : IDisposable
    {
        Task<bool> Adicionar(ManualVoo manualVoo);
        Task<bool> Atualizar(ManualVoo manualVoo);
        Task<bool> Remover(Guid id);
    }
}
