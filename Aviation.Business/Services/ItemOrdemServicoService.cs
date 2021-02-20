using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class ItemOrdemServicoService : BaseService, IItemOrdemServicoServices
    {
        private readonly IItemOrdemServicoRepository _itemOrdemServicoRepository;

        public ItemOrdemServicoService(IItemOrdemServicoRepository itemOrdemServicoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _itemOrdemServicoRepository = itemOrdemServicoRepository;
        }

        public async Task<bool> Adicionar(ItemOrdemServico itemOrdemServico)
        {
            if (!ExecutarValidacao(new ItemOrdemServicoValidation(), itemOrdemServico)) return false;

            await _itemOrdemServicoRepository.Adicionar(itemOrdemServico);
            return true;
        }

        public async Task<bool> Atualizar(ItemOrdemServico itemOrdemServico)
        {
            if (!ExecutarValidacao(new ItemOrdemServicoValidation(), itemOrdemServico)) return false;

            await _itemOrdemServicoRepository.Atualizar(itemOrdemServico);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _itemOrdemServicoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _itemOrdemServicoRepository?.Dispose();
        }
    }
}
