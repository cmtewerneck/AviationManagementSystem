using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IOrdemServicoRepository : IRepository<OrdemServico>
    {
        Task<IEnumerable<OrdemServico>> ObterOrdensServicoPorAeronave(Guid aeronaveId);

        Task<IEnumerable<OrdemServico>> ObterOrdensServicosAeronaves();

        Task<IEnumerable<OrdemServico>> ObterOrdensServicosItens();
    }
}