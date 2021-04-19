using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAeronaveDocumentoService : IDisposable
    {
        Task<bool> Atualizar(AeronaveDocumento aeronaveDocumento);
        Task<bool> Adicionar(AeronaveDocumento aeronaveDocumento);
        Task<bool> Remover(Guid id);
    }
}
