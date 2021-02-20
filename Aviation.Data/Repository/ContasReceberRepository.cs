using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;

namespace AviationManagementApi.Data.Repository
{
    public class ContasReceberRepository : ContasRepository<ContasReceber>, IContasReceberRepository
    {
        public ContasReceberRepository(AviationManagementDbContext context) : base(context) { }
    }
}
