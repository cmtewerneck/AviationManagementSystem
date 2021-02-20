using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class CursoService : BaseService, ICursoServices
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<bool> Adicionar(Curso curso)
        {
            if (!ExecutarValidacao(new CursoValidation(), curso)) return false;

            if (_cursoRepository.Buscar(f => f.Codigo == curso.Codigo).Result.Any())
            {
                Notificar("Já existe um curso com este código.");
                return false;
            }

            await _cursoRepository.Adicionar(curso);
            return true;
        }

        public async Task<bool> Atualizar(Curso curso)
        {
            if (!ExecutarValidacao(new CursoValidation(), curso)) return false;

            if (_cursoRepository.Buscar(f => f.Codigo == curso.Codigo && f.Id != curso.Id).Result.Any())
            {
                Notificar("Já existe um curso com este código.");
                return false;
            }

            await _cursoRepository.Atualizar(curso);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _cursoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _cursoRepository?.Dispose();
        }
    }
}
