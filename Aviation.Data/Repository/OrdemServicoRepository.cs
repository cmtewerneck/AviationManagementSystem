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
    public class OrdemServicoRepository : Repository<OrdemServico>, IOrdemServicoRepository
    {
        public OrdemServicoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<OrdemServico>> ObterOrdensServicoPorAeronave(Guid aeronaveId)
        {
            return await Buscar(p => p.AeronaveId == aeronaveId);
        }

        public async Task<IEnumerable<OrdemServico>> ObterOrdensServicosAeronaves()
        {
            return await Db.OrdensServico
                .Include(f => f.Aeronave)
                .OrderBy(p => p.DataAbertura)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<OrdemServico>> ObterOrdensServicosItens()
        {
            return await Db.OrdensServico
                .Include(f => f.Itens)
                .OrderBy(p => p.DataAbertura)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OrdemServico> ObterOrdemServicoAeronave(Guid id)
        {
            return await Db.OrdensServico
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
