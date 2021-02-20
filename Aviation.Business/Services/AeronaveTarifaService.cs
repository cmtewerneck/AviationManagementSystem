using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class AeronaveTarifaService : BaseService, IAeronaveTarifaServices
    {
        private readonly IAeronaveTarifaRepository _aeronaveTarifaRepository;

        public AeronaveTarifaService(IAeronaveTarifaRepository aeronaveTarifaRepository,
                              INotificador notificador) : base(notificador)
        {
            _aeronaveTarifaRepository = aeronaveTarifaRepository;
        }

        public async Task<bool> Adicionar(AeronaveTarifa aeronaveTarifa)
        {
            if (!ExecutarValidacao(new AeronaveTarifaValidation(), aeronaveTarifa)) return false;

            await _aeronaveTarifaRepository.Adicionar(aeronaveTarifa);
            return true;
        }

        public async Task<bool> Atualizar(AeronaveTarifa aeronaveTarifa)
        {
            if (!ExecutarValidacao(new AeronaveTarifaValidation(), aeronaveTarifa)) return false;

            if (_aeronaveTarifaRepository.Buscar(f => f.Numeracao == aeronaveTarifa.Numeracao && f.Id != aeronaveTarifa.Id).Result.Any())
            {
                Notificar("Já existe uma tarifa com esta numeração infomado.");
                return false;
            }

            await _aeronaveTarifaRepository.Atualizar(aeronaveTarifa);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _aeronaveTarifaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _aeronaveTarifaRepository?.Dispose();
        }
    }
}
