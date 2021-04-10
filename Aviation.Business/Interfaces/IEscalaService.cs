using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IEscalaService : IDisposable
    {
        Task<bool> Adicionar(Escala escala);
        Task<bool> Atualizar(Escala escala);
        Task<bool> Remover(Guid id);
    }
}
