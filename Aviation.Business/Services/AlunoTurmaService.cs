using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class AlunoTurmaService : BaseService, IAlunoTurmaServices
    {
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;

        public AlunoTurmaService(IAlunoTurmaRepository alunoTurmaRepository, 
                                 INotificador notificador) : base(notificador)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
        }


        public async Task<bool> Adicionar(AlunoTurma alunoTurma)
        {
            if (!ExecutarValidacao(new AlunoTurmaValidation(), alunoTurma)) return false;

            await _alunoTurmaRepository.Adicionar(alunoTurma);
            return true;
        }

        public async Task<bool> Atualizar(AlunoTurma alunoTurma)
        {
            if (!ExecutarValidacao(new AlunoTurmaValidation(), alunoTurma)) return false;

            await _alunoTurmaRepository.Atualizar(alunoTurma);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _alunoTurmaRepository.Remover(id);
            return true;
        }
        
        public void Dispose()
        {
            _alunoTurmaRepository?.Dispose();
        }
    }
}
