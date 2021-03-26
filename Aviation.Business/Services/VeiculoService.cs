using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class VeiculoService : BaseService, IVeiculoServices
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository,
                              INotificador notificador) : base(notificador)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<bool> Adicionar(Veiculo veiculo)
        {
            if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return false;

            if (_veiculoRepository.Buscar(f => f.Placa == veiculo.Placa).Result.Any())
            {
                Notificar("Já existe um veículo com esta placa.");
                return false;
            }

            await _veiculoRepository.Adicionar(veiculo);
            return true;
        }

        public async Task<bool> Atualizar(Veiculo veiculo)
        {
            if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return false;

            if (_veiculoRepository.Buscar(f => f.Placa == veiculo.Placa && f.Id != veiculo.Id).Result.Any())
            {
                Notificar("Já existe um veículo com esta placa.");
                return false;
            }

            await _veiculoRepository.Atualizar(veiculo);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_veiculoRepository.ObterVeiculoGastos(id).Result.VeiculoGastos.Any())
            {
                Notificar("O veículo possui gastos cadastrados. Exclua o gasto primeiro ou mude o status do veículo para INATIVO!");
                return false;
            }

            if (_veiculoRepository.ObterVeiculoMultas(id).Result.VeiculoGastos.Any())
            {
                Notificar("O veículo possui multas cadastradas. Exclua a multa primeiro ou mude o status do veículo para INATIVO!");
                return false;
            }

            await _veiculoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _veiculoRepository?.Dispose();
        }
    }
}
