using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IServicoServices : IDisposable
    {
        Task<bool> Adicionar(Servico servico);
        Task<bool> Atualizar(Servico servico);
        Task<bool> Remover(Guid id);
    }
}
