using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class ProdutoService : BaseService, IProdutoServices
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return false;

            await _produtoRepository.Adicionar(produto);
            return true;
        }

        public async Task<bool> Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return false;

            await _produtoRepository.Atualizar(produto);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
