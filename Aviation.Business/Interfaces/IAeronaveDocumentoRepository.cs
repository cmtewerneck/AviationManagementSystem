using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAeronaveDocumentoRepository : IRepository<AeronaveDocumento>
    {
        Task<AeronaveDocumento> ObterDocumentoAeronave(Guid id);

        Task<IEnumerable<AeronaveDocumento>> ObterDocumentosPorAeronave(Guid aeronaveId);
        
        Task<IEnumerable<AeronaveDocumento>> ObterDocumentosAeronaves();
    }
}
