using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;

namespace AviationManagementApi.Data.Repository
{
    public class ClienteRepository : PessoaRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AviationManagementDbContext context) : base(context) { }
    }
}
