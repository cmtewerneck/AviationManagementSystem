using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAeronaveTarifaRepository : IRepository<AeronaveTarifa>
    {
        Task<IEnumerable<AeronaveTarifa>> ObterTarifasPorAeronave(Guid aeronaveId);
        
        Task<IEnumerable<AeronaveTarifa>> ObterTarifasAeronaves();

        Task<IEnumerable<AeronaveTarifa>> ObterTarifasInfraeroAeronaves();
        
        Task<IEnumerable<AeronaveTarifa>> ObterTarifasDeceaAeronaves();

        Task<AeronaveTarifa> ObterTarifaAeronave(Guid id);

        Task<AeronaveTarifa> ObterTarifaInfraeroAeronave(Guid id);
        
        Task<AeronaveTarifa> ObterTarifaDeceaAeronave(Guid id);
    }
}
