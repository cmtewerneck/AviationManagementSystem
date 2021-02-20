using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;

namespace AviationManagementApi.Data.Repository
{
    public class LegislacaoRepository : Repository<Legislacao>, ILegislacaoRepository
    {
        public LegislacaoRepository(AviationManagementDbContext context) : base(context) { }
    }
}
