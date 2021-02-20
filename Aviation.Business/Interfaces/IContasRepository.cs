using AviationManagementApi.Business.Models;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IContasRepository<TEntity> : IRepository<TEntity> where TEntity : Contas
    {
    }
}
