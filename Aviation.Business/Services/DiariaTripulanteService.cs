using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class DiariaTripulanteService : BaseService, IDiariaTripulanteService
    {
        private readonly IDiariaTripulanteRepository _diariaTripulanteRepository;

        public DiariaTripulanteService(IDiariaTripulanteRepository diariaTripulanteRepository,
                              INotificador notificador) : base(notificador)
        {
            _diariaTripulanteRepository = diariaTripulanteRepository;
        }

        public async Task<bool> Adicionar(DiariaTripulante diariaTripulante)
        {
            if (!ExecutarValidacao(new DiariaTripulanteValidation(), diariaTripulante)) return false;

            await _diariaTripulanteRepository.Adicionar(diariaTripulante);
            return true;
        }

        public async Task<bool> Atualizar(DiariaTripulante diariaTripulante)
        {
            if (!ExecutarValidacao(new DiariaTripulanteValidation(), diariaTripulante)) return false;

            await _diariaTripulanteRepository.Atualizar(diariaTripulante);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _diariaTripulanteRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _diariaTripulanteRepository?.Dispose();
        }
    }
}
