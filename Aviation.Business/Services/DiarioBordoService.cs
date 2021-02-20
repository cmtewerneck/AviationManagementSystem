using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class DiarioBordoService : BaseService, IDiarioBordoServices
    {
        private readonly IDiarioBordoRepository _diarioBordoRepository;

        public DiarioBordoService(IDiarioBordoRepository diarioBordoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _diarioBordoRepository = diarioBordoRepository;
        }

        public async Task<bool> Adicionar(DiarioBordo diarioBordo)
        {
            if (!ExecutarValidacao(new DiarioBordoValidation(), diarioBordo)) return false;

            if ((_diarioBordoRepository.Buscar(f => f.Data == diarioBordo.Data).Result.Any()) && (_diarioBordoRepository.Buscar(f => f.HoraAcionamento == diarioBordo.HoraAcionamento).Result.Any()))
            {
                    Notificar("Já existe um lançamento nessa data com esse horário de acionamento.");
                    return false;
            }

            await _diarioBordoRepository.Adicionar(diarioBordo);
            return true;
        }

        public async Task<bool> Atualizar(DiarioBordo diarioBordo)
        {
            if (!ExecutarValidacao(new DiarioBordoValidation(), diarioBordo)) return false;

            if ((_diarioBordoRepository.Buscar(f => f.Data == diarioBordo.Data && f.Id != diarioBordo.Id).Result.Any()) && (_diarioBordoRepository.Buscar(f => f.HoraAcionamento == diarioBordo.HoraAcionamento && f.Id != diarioBordo.Id).Result.Any()))
            {
                    Notificar("Já existe um lançamento nessa data com esse horário de acionamento.");
                    return false;
            }

            await _diarioBordoRepository.Atualizar(diarioBordo);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _diarioBordoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _diarioBordoRepository?.Dispose();
        }
    }
}
