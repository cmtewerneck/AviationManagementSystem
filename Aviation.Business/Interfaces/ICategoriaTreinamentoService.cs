using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ICategoriaTreinamentoService : IDisposable
    {
        Task<bool> Adicionar(CategoriaTreinamento categoriaTreinamento);
        Task<bool> Atualizar(CategoriaTreinamento categoriaTreinamento);
        Task<bool> Remover(Guid id);
    }
}
