using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ICategoriaVooRepository : IRepository<CategoriaVoo>
    {
        Task<IEnumerable<CategoriaVoo>> ObterCategoriasVoos();
        Task<CategoriaVoo> ObterCategoriaVoo(Guid id);
    }
}
