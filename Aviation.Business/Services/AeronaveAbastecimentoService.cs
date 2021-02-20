using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class AeronaveAbastecimentoService : BaseService, IAeronaveAbastecimentoServices
    {
        private readonly IAeronaveAbastecimentoRepository _abastecimentoRepository;

        public AeronaveAbastecimentoService(IAeronaveAbastecimentoRepository abastecimentoRepository,
                              INotificador notificador) : base(notificador)
        {
            _abastecimentoRepository = abastecimentoRepository;
        }

        public async Task<bool> Adicionar(AeronaveAbastecimento abastecimento)
        {
            if (!ExecutarValidacao(new AeronaveAbastecimentoValidation(), abastecimento)) return false;

            await _abastecimentoRepository.Adicionar(abastecimento);
            return true;
        }

        public async Task<bool> Atualizar(AeronaveAbastecimento abastecimento)
        {
            if (!ExecutarValidacao(new AeronaveAbastecimentoValidation(), abastecimento)) return false;

            //if (_abastecimentoRepository.Buscar(f => f.Cupom == abastecimento.Cupom && f.Id != abastecimento.Id).Result.Any())
            //{
            //    Notificar("Já existe um cupom de abastecimento com este número cadastrado.");
            //    return false;
            //} Comentado porque pode haver 2 cupon iguais de diferentes fornecedores

            await _abastecimentoRepository.Atualizar(abastecimento);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _abastecimentoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _abastecimentoRepository?.Dispose();
        }
    }
}
