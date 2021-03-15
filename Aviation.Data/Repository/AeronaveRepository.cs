using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Data.Repository
{
    public class AeronaveRepository : Repository<Aeronave>, IAeronaveRepository
    {
        public AeronaveRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<Aeronave> ObterAeronaveAbastecimentos(Guid id)
        {
            return await Db.Aeronaves
                .Include(c => c.AeronavesAbastecimentos)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Aeronave> ObterAeronaveTarifas(Guid id)
        {
            return await Db.Aeronaves
                .Include(c => c.AeronaveTarifas)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
