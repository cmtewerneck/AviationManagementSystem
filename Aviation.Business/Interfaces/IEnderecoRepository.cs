using System;
using System.Threading.Tasks;
using AviationManagementApi.Business.Models;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}