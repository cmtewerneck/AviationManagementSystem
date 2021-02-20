using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;

namespace AviationManagementApi.Data.Repository
{
    public class ContasPagarRepository : ContasRepository<ContasPagar>, IContasPagarRepository
    {
        public ContasPagarRepository(AviationManagementDbContext context) : base(context) { }
    }
}
