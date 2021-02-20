using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Data.Repository
{
    public class ItemOrdemServicoRepository : Repository<ItemOrdemServico>, IItemOrdemServicoRepository
    {
        public ItemOrdemServicoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<ItemOrdemServico> ObterItemOrdemServico(Guid id)
        {
            return await Db.ItensOrdensServico.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<ItemOrdemServico>> ObterItensOrdemServico()
        {
            return await Db.ItensOrdensServico.AsNoTracking().ToListAsync();
        }
    }
}
