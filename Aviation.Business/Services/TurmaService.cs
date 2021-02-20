using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class TurmaServices : BaseService, ITurmaServices
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaServices(ITurmaRepository turmaRepository,
                              INotificador notificador) : base(notificador)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<bool> Adicionar(Turma turma)
        {
            if (!ExecutarValidacao(new TurmaValidation(), turma)) return false;

            if (_turmaRepository.Buscar(f => f.Codigo == turma.Codigo).Result.Any())
            {
                Notificar("Já existe uma turma com este código.");
                return false;
            }

            await _turmaRepository.Adicionar(turma);
            return true;
        }

        public async Task<bool> Atualizar(Turma turma)
        {
            if (!ExecutarValidacao(new TurmaValidation(), turma)) return false;

            if (_turmaRepository.Buscar(f => f.Codigo == turma.Codigo && f.Id != turma.Id).Result.Any())
            {
                Notificar("Já existe uma turma com este código.");
                return false;
            }

            await _turmaRepository.Atualizar(turma);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _turmaRepository.Remover(id);
            return true;
        }
        
        public void Dispose()
        {
            _turmaRepository?.Dispose();
        }
    }
}
