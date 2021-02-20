using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;

namespace AviationManagementApi.Data.Repository
{
    public class DiarioBordoRepository : Repository<DiarioBordo>, IDiarioBordoRepository
    {
        public DiarioBordoRepository(AviationManagementDbContext context) : base(context) { }
    }
}
