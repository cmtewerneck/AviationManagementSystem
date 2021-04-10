using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ITreinamentoRepository : IRepository<Treinamento>
    {
        Task<IEnumerable<Treinamento>> ObterTreinamentosColaboradoresCategorias();
        
        Task<Treinamento> ObterTreinamentoColaboradorCategoria(Guid id);
    }
}
