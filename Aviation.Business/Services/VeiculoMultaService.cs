using System;
using System.Linq;
using System.Threading.Tasks;
using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;

namespace AviationManagementApi.Business.Services
{
    public class VeiculoMultaService : BaseService, IVeiculoMultaServices
    {
        private readonly IVeiculoMultaRepository _multaRepository;

        public VeiculoMultaService(IVeiculoMultaRepository multaRepository,
                              INotificador notificador) : base(notificador)
        {
            _multaRepository = multaRepository;
        }

        public async Task<bool> Adicionar(VeiculoMulta veiculoMulta)
        {
            if (!ExecutarValidacao(new VeiculoMultaValidation(), veiculoMulta)) return false;

            if (_multaRepository.Buscar(f => f.AutoInfracao == veiculoMulta.AutoInfracao).Result.Any())
            {
                Notificar("Já existe esse auto de infração.");
                return false;
            }

            await _multaRepository.Adicionar(veiculoMulta);
            return true;
        }

        public async Task<bool> Atualizar(VeiculoMulta veiculoMulta)
        {
            if (!ExecutarValidacao(new VeiculoMultaValidation(), veiculoMulta)) return false;

            if (_multaRepository.Buscar(f => f.AutoInfracao == veiculoMulta.AutoInfracao && f.Id != veiculoMulta.Id).Result.Any())
            {
                Notificar("Já existe esse auto de infração.");
                return false;
            }

            await _multaRepository.Atualizar(veiculoMulta);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _multaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _multaRepository?.Dispose();
        }
    }
}
