using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class AeronaveDiretrizService : BaseService, IAeronaveDiretrizService
    {
        private readonly IAeronaveDiretrizRepository _aeronaveDiretrizRepository;

        public AeronaveDiretrizService(IAeronaveDiretrizRepository aeronaveDiretrizRepository,
                              INotificador notificador) : base(notificador)
        {
            _aeronaveDiretrizRepository = aeronaveDiretrizRepository;
        }

        public async Task<bool> Adicionar(AeronaveDiretriz aeronaveDiretriz)
        {
            if (!ExecutarValidacao(new AeronaveDiretrizValidation(), aeronaveDiretriz)) return false;

            if (_aeronaveDiretrizRepository.Buscar(f => f.Titulo == aeronaveDiretriz.Titulo && f.AeronaveId == aeronaveDiretriz.AeronaveId).Result.Any())
            {
                Notificar("Já existe este diretriz para esta aeronave.");
                return false;
            }

            await _aeronaveDiretrizRepository.Adicionar(aeronaveDiretriz);
            return true;
        }

        public async Task<bool> Atualizar(AeronaveDiretriz aeronaveDiretriz)
        {
            if (!ExecutarValidacao(new AeronaveDiretrizValidation(), aeronaveDiretriz)) return false;

            if (_aeronaveDiretrizRepository.Buscar(f => f.Titulo == aeronaveDiretriz.Titulo && f.AeronaveId == aeronaveDiretriz.AeronaveId && f.Id != aeronaveDiretriz.Id).Result.Any())
            {
                Notificar("Já existe este diretriz para esta aeronave.");
                return false;
            }

            await _aeronaveDiretrizRepository.Atualizar(aeronaveDiretriz);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _aeronaveDiretrizRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _aeronaveDiretrizRepository?.Dispose();
        }
    }
}
