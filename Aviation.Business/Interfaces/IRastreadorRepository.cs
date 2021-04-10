using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IRastreadorRepository : IRepository<Rastreador>
    {
        Task<IEnumerable<Rastreador>> ObterRastreadoresAeronaves();

        Task<Rastreador> ObterRastreadorAeronave(Guid id);
    }
}
