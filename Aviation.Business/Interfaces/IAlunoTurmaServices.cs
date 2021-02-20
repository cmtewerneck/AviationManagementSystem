using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAlunoTurmaServices : IDisposable
    {
        Task<bool> Adicionar(AlunoTurma alunoTurma);
        Task<bool> Atualizar(AlunoTurma alunoTurma);
        Task<bool> Remover(Guid id);
    }
}
