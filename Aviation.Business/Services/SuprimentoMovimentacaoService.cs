using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class SuprimentoMovimentacaoService : BaseService, ISuprimentoMovimentacaoServices
    {
        private readonly ISuprimentoMovimentacaoRepository _movimentacaoRepository;

        public SuprimentoMovimentacaoService(ISuprimentoMovimentacaoRepository movimentacaoRepository,
                              INotificador notificador) : base(notificador)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<bool> Adicionar(SuprimentoMovimentacao suprimentoMovimentacao)
        {
            if (!ExecutarValidacao(new SuprimentoMovimentacaoValidation(), suprimentoMovimentacao)) return false;

            await _movimentacaoRepository.Adicionar(suprimentoMovimentacao);
            return true;
        }

        public async Task<bool> Atualizar(SuprimentoMovimentacao suprimentoMovimentacao)
        {
            if (!ExecutarValidacao(new SuprimentoMovimentacaoValidation(), suprimentoMovimentacao)) return false;

            await _movimentacaoRepository.Atualizar(suprimentoMovimentacao);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _movimentacaoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _movimentacaoRepository?.Dispose();
        }
    }
}
