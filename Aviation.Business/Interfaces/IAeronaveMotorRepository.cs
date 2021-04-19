using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAeronaveMotorRepository : IRepository<AeronaveMotor>
    {
        Task<AeronaveMotor> ObterMotorAeronave(Guid id);

        Task<IEnumerable<AeronaveMotor>> ObterMotoresPorAeronave(Guid aeronaveId);
        
        Task<IEnumerable<AeronaveMotor>> ObterMotoresAeronaves();
    }
}
