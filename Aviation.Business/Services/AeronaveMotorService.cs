using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class AeronaveMotorService : BaseService, IAeronaveMotorService
    {
        private readonly IAeronaveMotorRepository _aeronaveMotorRepository;

        public AeronaveMotorService(IAeronaveMotorRepository aeronaveMotorRepository,
                              INotificador notificador) : base(notificador)
        {
            _aeronaveMotorRepository = aeronaveMotorRepository;
        }

        public async Task<bool> Adicionar(AeronaveMotor aeronaveMotor)
        {
            if (!ExecutarValidacao(new AeronaveMotorValidation(), aeronaveMotor)) return false;

            if (_aeronaveMotorRepository.Buscar(f => f.NumeroSerie == aeronaveMotor.NumeroSerie).Result.Any())
            {
                Notificar("Já existe um motor com este número de série.");
                return false;
            }

            await _aeronaveMotorRepository.Adicionar(aeronaveMotor);
            return true;
        }

        public async Task<bool> Atualizar(AeronaveMotor aeronaveMotor)
        {
            if (!ExecutarValidacao(new AeronaveMotorValidation(), aeronaveMotor)) return false;

            if (_aeronaveMotorRepository.Buscar(f => f.NumeroSerie == aeronaveMotor.NumeroSerie && f.Id != aeronaveMotor.Id).Result.Any())
            {
                Notificar("Já existe um motor com este número de série.");
                return false;
            }

            await _aeronaveMotorRepository.Atualizar(aeronaveMotor);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _aeronaveMotorRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _aeronaveMotorRepository?.Dispose();
        }
    }
}
