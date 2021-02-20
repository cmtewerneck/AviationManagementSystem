using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IOficioEmitidoServices : IDisposable
    {
        Task<bool> Adicionar(OficioEmitido oficioEmitido);
        Task<bool> Atualizar(OficioEmitido oficioEmitido);
        Task<bool> Remover(Guid id);
    }
}
