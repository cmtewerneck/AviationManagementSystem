using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ICursoServices : IDisposable
    {
        Task<bool> Adicionar(Curso curso);
        Task<bool> Atualizar(Curso curso);
        Task<bool> Remover(Guid id);
    }
}
