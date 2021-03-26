using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Data.Repository
{
    public class VeiculoMultaRepository : Repository<VeiculoMulta>, IVeiculoMultaRepository
    {
        public VeiculoMultaRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<VeiculoMulta>> ObterMultasPorVeiculo(Guid veiculoId)
        {
            return await Buscar(p => p.VeiculoId == veiculoId);
        }

        public async Task<IEnumerable<VeiculoMulta>> ObterMultasVeiculos()
        {
            return await Db.VeiculoMultas
                .AsNoTracking()
                .Include(f => f.Veiculo)
                .OrderBy(p => p.Data)
                .ToListAsync();
        }

        public async Task<VeiculoMulta> ObterMultaVeiculo(Guid id)
        {
            return await Db.VeiculoMultas
                .AsNoTracking()
                .Include(f => f.Veiculo)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
