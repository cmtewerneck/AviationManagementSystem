using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class LegislacaoService : BaseService, ILegislacaoServices
    {
        private readonly ILegislacaoRepository _legislacaoRepository;

        public LegislacaoService(ILegislacaoRepository legislacaoRepository,
                              INotificador notificador) : base(notificador)
        {
            _legislacaoRepository = legislacaoRepository;
        }

        public async Task<bool> Adicionar(Legislacao legislacao)
        {
            if (!ExecutarValidacao(new LegislacaoValidation(), legislacao)) return false;

            if ((_legislacaoRepository.Buscar(f => f.Numero == legislacao.Numero).Result.Any()) && (_legislacaoRepository.Buscar(f => f.Emenda == legislacao.Emenda).Result.Any()))
            {
                Notificar("Já existe essa legislação com esse número e emenda");
                return false;
            }

            await _legislacaoRepository.Adicionar(legislacao);
            return true;
        }

        public async Task<bool> Atualizar(Legislacao legislacao)
        {
            if (!ExecutarValidacao(new LegislacaoValidation(), legislacao)) return false;

            if ((_legislacaoRepository.Buscar(f => f.Numero == legislacao.Numero).Result.Any()) && (_legislacaoRepository.Buscar(f => f.Emenda == legislacao.Emenda).Result.Any()))
            {
                Notificar("Já existe essa legislação com esse número e emenda");
                return false;
            }

            await _legislacaoRepository.Atualizar(legislacao);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _legislacaoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _legislacaoRepository?.Dispose();
        }
    }
}
