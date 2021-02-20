using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class ManualEmpresaService : BaseService, IManualEmpresaServices
    {
        private readonly IManualEmpresaRepository _manualEmpresaRepository;

        public ManualEmpresaService(IManualEmpresaRepository manualEmpresaRepository,
                              INotificador notificador) : base(notificador)
        {
            _manualEmpresaRepository = manualEmpresaRepository;
        }

        public async Task<bool> Adicionar(ManualEmpresa manualEmpresa)
        {
            if (!ExecutarValidacao(new ManualEmpresaValidation(), manualEmpresa)) return false;

            await _manualEmpresaRepository.Adicionar(manualEmpresa);
            return true;
        }

        public async Task<bool> Atualizar(ManualEmpresa manualEmpresa)
        {
            if (!ExecutarValidacao(new ManualEmpresaValidation(), manualEmpresa)) return false;

            await _manualEmpresaRepository.Atualizar(manualEmpresa);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _manualEmpresaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _manualEmpresaRepository?.Dispose();
        }
    }
}
