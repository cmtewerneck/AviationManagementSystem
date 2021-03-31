using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class LicencaHabilitacaoService : BaseService, ILicencaHabilitacaoServices
    {
        private readonly ILicencaHabilitacaoRepository _licencaHabilitacaoRepository;

        public LicencaHabilitacaoService(ILicencaHabilitacaoRepository licencaHabilitacaoRepository,
                              INotificador notificador) : base(notificador)
        {
            _licencaHabilitacaoRepository = licencaHabilitacaoRepository;
        }

        public async Task<bool> Adicionar(LicencaHabilitacao licencaHabilitacao)
        {
            if (!ExecutarValidacao(new LicencaHabilitacaoValidation(), licencaHabilitacao)) return false;

            if ((_licencaHabilitacaoRepository.Buscar(f => f.Titulo == licencaHabilitacao.Titulo).Result.Any()) && (_licencaHabilitacaoRepository.Buscar(f => f.ColaboradorId == licencaHabilitacao.ColaboradorId).Result.Any()))
            {
                Notificar("Já existe essa licença cadastrada para esse aeronauta.");
                return false;
            }

            await _licencaHabilitacaoRepository.Adicionar(licencaHabilitacao);
            return true;
        }

        public async Task<bool> Atualizar(LicencaHabilitacao licencaHabilitacao)
        {
            if (!ExecutarValidacao(new LicencaHabilitacaoValidation(), licencaHabilitacao)) return false;

            if ((_licencaHabilitacaoRepository.Buscar(f => f.Titulo == licencaHabilitacao.Titulo).Result.Any()) && (_licencaHabilitacaoRepository.Buscar(f => f.ColaboradorId == licencaHabilitacao.ColaboradorId).Result.Any()))
            {
                Notificar("Já existe essa licença para esse aeronauta.");
                return false;
            }

            await _licencaHabilitacaoRepository.Atualizar(licencaHabilitacao);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _licencaHabilitacaoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _licencaHabilitacaoRepository?.Dispose();
        }
    }
}
