using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;

namespace AviationManagementApi.Data.Repository
{
    public class ContasRepository<TEntity> : Repository<TEntity>, IContasRepository<TEntity> where TEntity : Contas, new()
    {
        public ContasRepository(AviationManagementDbContext context) : base(context) { }
    }
}
