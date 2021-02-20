using System;
using System.Threading.Tasks;
using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AviationManagementApi.Data.Repository
{
    public class FornecedorRepository : PessoaRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorProdutos(Guid id)
        {
            return await Db.Fornecedores
                .Include(c => c.Produtos)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores
                .Include(c => c.Endereco)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
