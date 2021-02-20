using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAeronaveAbastecimentoRepository : IRepository<AeronaveAbastecimento>
    {
        Task<AeronaveAbastecimento> ObterAbastecimentoAeronave(Guid id);

        Task<IEnumerable<AeronaveAbastecimento>> ObterAbastecimentosPorAeronave(Guid aeronaveId);
        
        Task<IEnumerable<AeronaveAbastecimento>> ObterAbastecimentosAeronaves();
    }
}
