using System;
using System.Threading.Tasks;
using AviationManagementApi.Business.Models;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IFornecedorRepository : IPessoaRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorProdutos(Guid id);

        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}
