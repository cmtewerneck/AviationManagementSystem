using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IVeiculoGastoRepository : IRepository<VeiculoGasto>
    {
        Task<IEnumerable<VeiculoGasto>> ObterGastosPorVeiculo(Guid veiculoId);

        Task<IEnumerable<VeiculoGasto>> ObterGastosVeiculos();

        Task<IEnumerable<VeiculoGasto>> ObterGastosVeiculosMotoristas();

        Task<VeiculoGasto> ObterGastoVeiculo(Guid id);

        Task<VeiculoGasto> ObterGastoVeiculoMotorista(Guid id);
    }
}
