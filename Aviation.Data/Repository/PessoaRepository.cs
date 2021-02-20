using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;

namespace AviationManagementApi.Data.Repository
{
    public abstract class PessoaRepository<TEntity> : Repository<TEntity>, IPessoaRepository<TEntity> where TEntity : Pessoa, new()
    {
        public PessoaRepository(AviationManagementDbContext context) : base(context) { }
    }
}
