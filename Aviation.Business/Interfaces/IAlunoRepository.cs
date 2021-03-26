using AviationManagementApi.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAlunoRepository : IPessoaRepository<Aluno>
    {
        Task<IEnumerable<Aluno>> ObterAlunosTurmasCurso();
    }
}
