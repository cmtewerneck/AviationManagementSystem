using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAeronaveServices : IDisposable
    {
        Task<bool> Adicionar(Aeronave aeronave);
        Task<bool> Atualizar(Aeronave aeronave);
        Task<bool> Remover(Guid id);
    }
}
