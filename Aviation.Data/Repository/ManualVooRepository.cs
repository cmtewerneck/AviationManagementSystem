using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;

namespace AviationManagementApi.Data.Repository
{
    public class ManualVooRepository : Repository<ManualVoo>, IManualVooRepository
    {
        public ManualVooRepository(AviationManagementDbContext context) : base(context) { }
    }
}
