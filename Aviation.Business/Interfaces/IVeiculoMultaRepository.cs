using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IVeiculoMultaRepository : IRepository<VeiculoMulta>
    {
        Task<IEnumerable<VeiculoMulta>> ObterMultasPorVeiculo(Guid veiculoId);
    }
}
