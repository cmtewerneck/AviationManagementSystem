using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IManualEmpresaServices : IDisposable
    {
        Task<bool> Adicionar(ManualEmpresa manualEmpresa);
        Task<bool> Atualizar(ManualEmpresa manualEmpresa);
        Task<bool> Remover(Guid id);
    }
}
