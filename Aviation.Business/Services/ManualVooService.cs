using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class ManualVooService : BaseService, IManualVooServices
    {
        private readonly IManualVooRepository _manualVooRepository;

        public ManualVooService(IManualVooRepository manualVooRepository,
                              INotificador notificador) : base(notificador)
        {
            _manualVooRepository = manualVooRepository;
        }

        public async Task<bool> Adicionar(ManualVoo manualVoo)
        {
            if (!ExecutarValidacao(new ManualVooValidation(), manualVoo)) return false;

            await _manualVooRepository.Adicionar(manualVoo);
            return true;
        }

        public async Task<bool> Atualizar(ManualVoo manualVoo)
        {
            if (!ExecutarValidacao(new ManualVooValidation(), manualVoo)) return false;

            await _manualVooRepository.Atualizar(manualVoo);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _manualVooRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _manualVooRepository?.Dispose();
        }
    }
}
