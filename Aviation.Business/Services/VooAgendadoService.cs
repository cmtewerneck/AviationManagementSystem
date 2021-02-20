using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class VooAgendadoService : BaseService, IVooAgendadoServices
    {
        private readonly IVooAgendadoRepository _vooAgendadoRepository;

        public VooAgendadoService(IVooAgendadoRepository vooAgendadoRepository,
                              INotificador notificador) : base(notificador)
        {
            _vooAgendadoRepository = vooAgendadoRepository;
        }

        public async Task<bool> Adicionar(VooAgendado vooAgendado)
        {
            if (!ExecutarValidacao(new VooAgendadoValidation(), vooAgendado)) return false;

            if ((_vooAgendadoRepository.Buscar(f => f.Start == vooAgendado.Start).Result.Any()))
            {
                Notificar("Já existe um lançamento nesse horário.");
                return false;
            }

            await _vooAgendadoRepository.Adicionar(vooAgendado);
            return true;
        }

        public async Task<bool> Atualizar(VooAgendado vooAgendado)
        {
            if (!ExecutarValidacao(new VooAgendadoValidation(), vooAgendado)) return false;

            if (_vooAgendadoRepository.Buscar(f => f.Start == vooAgendado.Start && f.Id != vooAgendado.Id).Result.Any())
            {
                Notificar("Já existe um lançamento nesse horário.");
                return false;
            }

            await _vooAgendadoRepository.Atualizar(vooAgendado);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _vooAgendadoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _vooAgendadoRepository?.Dispose();
        }
    }
}
