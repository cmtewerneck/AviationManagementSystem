using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AviationManagementApi.Business.Models;

namespace AviationManagementApi.Business.Interfaces
{
    //--- Interface implementa IDisposable para liberar memória e só pode ser usada por classes onde TEntity herda Entity
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        #region Consulta

        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task<int> ObterTotalRegistros();
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        #endregion

        Task Adicionar(TEntity entity);
        Task Remover(Guid id);
        Task Atualizar(TEntity entity);

        Task<int> SaveChanges();
    }
}
