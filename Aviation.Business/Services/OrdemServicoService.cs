using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class OrdemServicoServices : BaseService, IOrdemServicoServices
    {
        private readonly IOrdemServicoRepository _ordemServicoRepository;

        public OrdemServicoServices(IOrdemServicoRepository ordemServicoRepository,
                                    INotificador notificador) : base(notificador)
        {
            _ordemServicoRepository = ordemServicoRepository;
        }

        public async Task<bool> Adicionar(OrdemServico ordemServico)
        {
            if (!ExecutarValidacao(new OrdemServicoValidation(), ordemServico)) return false;

            if (_ordemServicoRepository.Buscar(f => f.NumeroOrdem == ordemServico.NumeroOrdem).Result.Any())
            {
                Notificar("Já existe uma ordem com esta numeração.");
                return false;
            }

            await _ordemServicoRepository.Adicionar(ordemServico);
            return true;
        }

        public async Task<bool> Atualizar(OrdemServico ordemServico)
        {
            if (!ExecutarValidacao(new OrdemServicoValidation(), ordemServico)) return false;

            if (_ordemServicoRepository.Buscar(f => f.NumeroOrdem == ordemServico.NumeroOrdem&& f.Id != ordemServico.Id).Result.Any())
            {
                Notificar("Já existe uma ordem com esta numeração.");
                return false;
            }

            await _ordemServicoRepository.Atualizar(ordemServico);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _ordemServicoRepository.Remover(id);
            return true;
        }
        
        public void Dispose()
        {
            _ordemServicoRepository?.Dispose();
        }
    }
}
