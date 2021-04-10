using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IRastreadorService : IDisposable
    {
        Task<bool> Adicionar(Rastreador rastreador);
        Task<bool> Atualizar(Rastreador rastreador);
        Task<bool> Remover(Guid id);
    }
}
