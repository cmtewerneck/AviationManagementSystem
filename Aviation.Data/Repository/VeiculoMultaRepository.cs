using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using System;
using System.Collections.Generic;
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
    }
}
