using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IPassagemAereaService : IDisposable
    {
        Task<bool> Adicionar(PassagemAerea passagemAerea);
        Task<bool> Atualizar(PassagemAerea passagemAerea);
        Task<bool> Remover(Guid id);
    }
}
