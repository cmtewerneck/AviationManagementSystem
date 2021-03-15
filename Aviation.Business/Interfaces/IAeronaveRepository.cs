using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAeronaveRepository : IRepository<Aeronave>
    {
        Task<Aeronave> ObterAeronaveAbastecimentos(Guid id);
        Task<Aeronave> ObterAeronaveTarifas(Guid id);
    }
}
