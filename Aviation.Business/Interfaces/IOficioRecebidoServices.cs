using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IOficioRecebidoServices : IDisposable
    {
        Task<bool> Adicionar(OficioRecebido oficioRecebido);
        Task<bool> Atualizar(OficioRecebido oficioRecebido);
        Task<bool> Remover(Guid id);
    }
}
