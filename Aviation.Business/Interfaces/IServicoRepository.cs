using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IServicoRepository : IRepository<Servico>
    {
        Task<Servico> ObterServicoOrdensServico(Guid id);
    }
}