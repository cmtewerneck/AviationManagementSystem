using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class ServicoServices : BaseService, IServicoServices
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoServices(IServicoRepository servicoRepository,
                                    INotificador notificador) : base(notificador)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<bool> Adicionar(Servico servico)
        {
            if (!ExecutarValidacao(new ServicoValidation(), servico)) return false;

            if (_servicoRepository.Buscar(f => f.Codigo == servico.Codigo).Result.Any())
            {
                Notificar("Já existe um serviço com este código.");
                return false;
            }

            await _servicoRepository.Adicionar(servico);
            return true;
        }

        public async Task<bool> Atualizar(Servico servico)
        {
            if (!ExecutarValidacao(new ServicoValidation(), servico)) return false;

            if (_servicoRepository.Buscar(f => f.Codigo == servico.Codigo && f.Id != servico.Id).Result.Any())
            {
                Notificar("Já existe um serviço com este código.");
                return false;
            }

            await _servicoRepository.Atualizar(servico);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_servicoRepository.ObterServicoOrdensServico(id).Result.Itens.Any())
            {
                Notificar("O serviço possui ordens de serviço cadastradas! Excluir ordens ou mudar status do serviço como INATIVO!");
                return false;
            }

            await _servicoRepository.Remover(id);
            return true;
        }
        
        public void Dispose()
        {
            _servicoRepository?.Dispose();
        }
    }
}
