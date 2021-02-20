using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IPessoaServices<TEntity> : IDisposable where TEntity : Pessoa
    {
        Task<bool> Adicionar(TEntity entity);
        Task<bool> Atualizar(TEntity entity);
        Task<bool> Remover(Guid id);
    }
}
