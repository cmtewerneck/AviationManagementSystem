using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAeronaveDiretrizRepository : IRepository<AeronaveDiretriz>
    {
        Task<AeronaveDiretriz> ObterDiretrizAeronave(Guid id);

        Task<IEnumerable<AeronaveDiretriz>> ObterDiretrizesPorAeronave(Guid aeronaveId);
        
        Task<IEnumerable<AeronaveDiretriz>> ObterDiretrizesAeronaves();
    }
}
