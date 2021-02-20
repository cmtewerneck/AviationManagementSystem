using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ITurmaServices : IDisposable
    {
        Task<bool> Adicionar(Turma turma);
        Task<bool> Atualizar(Turma turma);
        Task<bool> Remover(Guid id);
    }
}
