using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Data.Repository
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<Veiculo> ObterVeiculoMultas(Guid id)
        {
            return await Db.Veiculos
                .Include(c => c.VeiculoMultas)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Veiculo> ObterVeiculoGastos(Guid id)
        {
            return await Db.Veiculos
                .Include(c => c.VeiculosGastos)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
