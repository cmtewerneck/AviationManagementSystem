using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ITreinamentoService : IDisposable
    {
        Task<bool> Adicionar(Treinamento treinamento);
        Task<bool> Atualizar(Treinamento treinamento);
        Task<bool> Remover(Guid id);
    }
}
