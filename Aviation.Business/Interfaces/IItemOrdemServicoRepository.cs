using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IItemOrdemServicoRepository : IRepository<ItemOrdemServico>
    {
        Task<ItemOrdemServico> ObterItemOrdemServico(Guid id);

        Task<IEnumerable<ItemOrdemServico>> ObterItensOrdemServico();
    }
}
