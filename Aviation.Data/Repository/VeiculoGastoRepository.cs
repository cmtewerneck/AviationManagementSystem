using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using System;
using System.Collections.Generic;
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
    }
}
