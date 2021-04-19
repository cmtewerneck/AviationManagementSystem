using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IVooAgendadoRepository : IRepository<VooAgendado>
    {
        Task<IEnumerable<VooAgendado>> ObterVoosAgendadosPorAeronave(Guid aeronaveId);

        Task<IEnumerable<VooAgendado>> ObterVoosAgendadosAeronaves();

        Task<IEnumerable<VooAgendado>> ObterVoosAgendadosAeronavesCategorias();

        Task<VooAgendado> ObterVooAgendadoAeronave(Guid id);
    }
}
