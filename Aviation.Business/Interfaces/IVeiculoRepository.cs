using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        Task<Veiculo> ObterVeiculoGastos(Guid id);
        
        Task<Veiculo> ObterVeiculoMultas(Guid id);
    }
}
