using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IVooAgendadoServices : IDisposable
    {
        Task<bool> Adicionar(VooAgendado vooAgendado);
        Task<bool> Atualizar(VooAgendado vooAgendado);
        Task<bool> Remover(Guid id);
    }
}
