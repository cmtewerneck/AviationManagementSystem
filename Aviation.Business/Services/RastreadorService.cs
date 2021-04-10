using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class RastreadorService : BaseService, IRastreadorService
    {
        private readonly IRastreadorRepository _rastreadorRepository;

        public RastreadorService(IRastreadorRepository rastreadorRepository,
                              INotificador notificador) : base(notificador)
        {
            _rastreadorRepository = rastreadorRepository;
        }

        public async Task<bool> Adicionar(Rastreador rastreador)
        {
            if (!ExecutarValidacao(new RastreadorValidation(), rastreador)) return false;

            if (_rastreadorRepository.Buscar(f => f.Codigo == rastreador.Codigo).Result.Any())
            {
                Notificar("Já existe um rastreador com este código.");
                return false;
            }

            await _rastreadorRepository.Adicionar(rastreador);
            return true;
        }

        public async Task<bool> Atualizar(Rastreador rastreador)
        {
            if (!ExecutarValidacao(new RastreadorValidation(), rastreador)) return false;

            if (_rastreadorRepository.Buscar(f => f.Codigo == rastreador.Codigo && f.Id != rastreador.Id).Result.Any())
            {
                Notificar("Já existe um rastreador com este código.");
                return false;
            }

            await _rastreadorRepository.Atualizar(rastreador);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _rastreadorRepository.Remover(id);
            return true;
        }
        
        public void Dispose()
        {
            _rastreadorRepository?.Dispose();
        }
    }
}
