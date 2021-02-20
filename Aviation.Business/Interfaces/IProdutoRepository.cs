using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> ObterProdutoFornecedor(Guid id);
        
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        
    }
}
