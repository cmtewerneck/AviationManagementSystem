using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;

namespace AviationManagementApi.Business.Services
{
    public class AlunoService : PessoaService<Aluno, AlunoValidation>, IAlunoServices
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository, INotificador notificador) : base(alunoRepository, notificador)
        {
            _alunoRepository = alunoRepository;
        }
    }
}
