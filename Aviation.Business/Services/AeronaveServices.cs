using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class AeronaveServices : BaseService, IAeronaveServices
    {
        private readonly IAeronaveRepository _aeronaveRepository;

        public AeronaveServices(IAeronaveRepository aeronaveRepository,
                              INotificador notificador) : base(notificador)
        {
            _aeronaveRepository = aeronaveRepository;
        }

        public async Task<bool> Adicionar(Aeronave aeronave)
        {
            if (!ExecutarValidacao(new AeronaveValidation(), aeronave)) return false;

            if (_aeronaveRepository.Buscar(f => f.Matricula == aeronave.Matricula).Result.Any())
            {
                Notificar("Já existe uma aeronave com esta matrícula.");
                return false;
            }

            await _aeronaveRepository.Adicionar(aeronave);
            return true;
        }

        public async Task<bool> Atualizar(Aeronave aeronave)
        {
            if (!ExecutarValidacao(new AeronaveValidation(), aeronave)) return false;

            if (_aeronaveRepository.Buscar(f => f.Matricula == aeronave.Matricula && f.Id != aeronave.Id).Result.Any())
            {
                Notificar("Já existe uma aeronave com esta matrícula.");
                return false;
            }

            await _aeronaveRepository.Atualizar(aeronave);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_aeronaveRepository.ObterAeronaveAbastecimentos(id).Result.AeronavesAbastecimentos.Any())
            {
                Notificar("A aeronave possui abastecimentos cadastrados! \n Favor excluir ou mudar o status da aeronave para INATIVA.");
                return false;
            }

            if (_aeronaveRepository.ObterAeronaveTarifas(id).Result.AeronaveTarifas.Any())
            {
                Notificar("A aeronave possui tarifas cadastradas! \n Favor excluir ou mudar o status da aeronave para INATIVA.");
                return false;
            }

            await _aeronaveRepository.Remover(id);
            return true;
        }
        
        public void Dispose()
        {
            _aeronaveRepository?.Dispose();
        }
    }
}
