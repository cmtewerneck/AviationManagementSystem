using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class PassagemAereaService : BaseService, IPassagemAereaService
    {
        private readonly IPassagemAereaRepository _passagemAereaRepository;

        public PassagemAereaService(IPassagemAereaRepository passagemAereaRepository,
                              INotificador notificador) : base(notificador)
        {
            _passagemAereaRepository = passagemAereaRepository;
        }

        public async Task<bool> Adicionar(PassagemAerea passagemAerea)
        {
            if (!ExecutarValidacao(new PassagemAereaValidation(), passagemAerea)) return false;

            await _passagemAereaRepository.Adicionar(passagemAerea);
            return true;
        }

        public async Task<bool> Atualizar(PassagemAerea passagemAerea)
        {
            if (!ExecutarValidacao(new PassagemAereaValidation(), passagemAerea)) return false;

            await _passagemAereaRepository.Atualizar(passagemAerea);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _passagemAereaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _passagemAereaRepository?.Dispose();
        }
    }
}
