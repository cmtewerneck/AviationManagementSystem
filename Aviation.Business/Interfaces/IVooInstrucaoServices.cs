using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IVooInstrucaoServices : IDisposable
    {
        Task<bool> Adicionar(VooInstrucao vooInstrucao);
        Task<bool> Atualizar(VooInstrucao vooInstrucao);
        Task<bool> Remover(Guid id);
    }
}
