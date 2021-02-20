using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IDiarioBordoServices : IDisposable
    {
        Task<bool> Adicionar(DiarioBordo diarioBordo);
        Task<bool> Atualizar(DiarioBordo diarioBordo);
        Task<bool> Remover(Guid id);
    }
}
