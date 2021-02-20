using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;

namespace AviationManagementApi.Data.Repository
{
    public class OficioRecebidoRepository : Repository<OficioRecebido>, IOficioRecebidoRepository
    {
        public OficioRecebidoRepository(AviationManagementDbContext context) : base(context) { }
    }
}
