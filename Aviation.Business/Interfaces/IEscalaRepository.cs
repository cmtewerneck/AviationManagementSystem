using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IEscalaRepository : IRepository<Escala>
    {
        Task<IEnumerable<Escala>> ObterEscalasTripulantes();

        Task<Escala> ObterEscalaTripulante(Guid id);
    }
}
