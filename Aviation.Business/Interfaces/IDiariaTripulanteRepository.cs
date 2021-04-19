using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IDiariaTripulanteRepository : IRepository<DiariaTripulante>
    {
        Task<DiariaTripulante> ObterDiariaTripulante(Guid id);

        Task<IEnumerable<DiariaTripulante>> ObterDiariasTripulantes();
    }
}
