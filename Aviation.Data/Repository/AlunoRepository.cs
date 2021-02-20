using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;

namespace AviationManagementApi.Data.Repository
{
    public class AlunoRepository : PessoaRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(AviationManagementDbContext context) : base(context) { }
    }
}
