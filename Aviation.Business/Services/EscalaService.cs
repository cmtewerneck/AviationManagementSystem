using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class EscalaService : BaseService, IEscalaService
    {
        private readonly IEscalaRepository _escalaRepository;

        public EscalaService(IEscalaRepository escalaRepository,
                                 INotificador notificador) : base(notificador)
        {
            _escalaRepository = escalaRepository;
        }

        public async Task<bool> Adicionar(Escala escala)
        {
            if (!ExecutarValidacao(new EscalaValidation(), escala)) return false;

            if ((_escalaRepository.Buscar(f => f.Data == escala.Data).Result.Any()) && (_escalaRepository.Buscar(f => f.Tripulante == escala.Tripulante).Result.Any()))
            {
                    Notificar("Já existe um lançamento nessa data para esse tripulante.");
                    return false;
            }

            await _escalaRepository.Adicionar(escala);
            return true;
        }

        public async Task<bool> Atualizar(Escala escala)
        {
            if (!ExecutarValidacao(new EscalaValidation(), escala)) return false;

            if ((_escalaRepository.Buscar(f => f.Data == escala.Data && f.Id != escala.Id).Result.Any()) && (_escalaRepository.Buscar(f => f.Tripulante == escala.Tripulante && f.Id != escala.Id).Result.Any()))
            {
                Notificar("Já existe um lançamento nessa data para esse tripulante.");
                return false;
            }

            await _escalaRepository.Atualizar(escala);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _escalaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _escalaRepository?.Dispose();
        }
    }
}
