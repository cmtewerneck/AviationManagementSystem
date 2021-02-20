using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
namespace AviationManagementApi.Data.Repository
{
    public class AeronaveRepository : Repository<Aeronave>, IAeronaveRepository
    {
        public AeronaveRepository(AviationManagementDbContext context) : base(context) { }
    }
}
