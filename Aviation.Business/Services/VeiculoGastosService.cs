using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class VeiculoGastosService : BaseService, IVeiculoGastoServices
    {
        private readonly IVeiculoGastoRepository _gastosVeiculoRepository;

        public VeiculoGastosService(IVeiculoGastoRepository gastosVeiculoRepository,
                              INotificador notificador) : base(notificador)
        {
            _gastosVeiculoRepository = gastosVeiculoRepository;
        }

        public async Task<bool> Adicionar(VeiculoGasto veiculoGasto)
        {
            if (!ExecutarValidacao(new VeiculoGastoValidation(), veiculoGasto)) return false;

            await _gastosVeiculoRepository.Adicionar(veiculoGasto);
            return true;
        }

        public async Task<bool> Atualizar(VeiculoGasto veiculoGasto)
        {
            if (!ExecutarValidacao(new VeiculoGastoValidation(), veiculoGasto)) return false;

            await _gastosVeiculoRepository.Atualizar(veiculoGasto);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _gastosVeiculoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _gastosVeiculoRepository?.Dispose();
        }
    }
}
