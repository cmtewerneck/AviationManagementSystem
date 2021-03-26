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
    public class VeiculoGastoRepository : Repository<VeiculoGasto>, IVeiculoGastoRepository
    {
        public VeiculoGastoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<VeiculoGasto>> ObterGastosPorVeiculo(Guid veiculoId)
        {
            return await Buscar(p => p.VeiculoId == veiculoId);
        }

        public async Task<IEnumerable<VeiculoGasto>> ObterGastosVeiculos()
        {
            return await Db.VeiculoGastos
                .AsNoTracking()
                .Include(f => f.Veiculo)
                .OrderBy(p => p.Data)
                .ToListAsync();
        }

        public async Task<IEnumerable<VeiculoGasto>> ObterGastosVeiculosMotoristas()
        {
            return await Db.VeiculoGastos
                .AsNoTracking()
                .Include(f => f.Veiculo)
                .Include(f => f.Motorista)
                .OrderBy(p => p.Data)
                .ToListAsync();
        }

        public async Task<VeiculoGasto> ObterGastoVeiculo(Guid id)
        {
            return await Db.VeiculoGastos
                .AsNoTracking()
                .Include(f => f.Veiculo)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<VeiculoGasto> ObterGastoVeiculoMotorista(Guid id)
        {
            return await Db.VeiculoGastos
                .AsNoTracking()
                .Include(f => f.Veiculo)
                .Include(f => f.Motorista)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
