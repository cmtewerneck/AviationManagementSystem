using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ICategoriaTreinamentoRepository : IRepository<CategoriaTreinamento>
    {
        Task<IEnumerable<CategoriaTreinamento>> ObterCategoriasTreinamentos();
        Task<CategoriaTreinamento> ObterCategoriaTreinamento(Guid id);
    }
}
