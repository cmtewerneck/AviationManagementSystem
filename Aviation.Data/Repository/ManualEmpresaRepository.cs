using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;

namespace AviationManagementApi.Data.Repository
{
    public class ManualEmpresaRepository : Repository<ManualEmpresa>, IManualEmpresaRepository
    {
        public ManualEmpresaRepository(AviationManagementDbContext context) : base(context) { }
    }
}
