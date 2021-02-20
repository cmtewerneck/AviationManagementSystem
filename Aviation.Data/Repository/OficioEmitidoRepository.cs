using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;

namespace AviationManagementApi.Data.Repository
{
    public class OficioEmitidoRepository : Repository<OficioEmitido>, IOficioEmitidoRepository
    {
        public OficioEmitidoRepository(AviationManagementDbContext context) : base(context) { }
    }
}
