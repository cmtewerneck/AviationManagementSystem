using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAlunoTurmaRepository : IRepository<AlunoTurma>
    {
        // Task<AlunoTurma> ObterAlunoTurma(Guid id);

        // Task<AlunoTurma> ObterAlunoPorTurma(Guid turmaId);

        // Task<int> ObterQuantidadeAlunosCadastrados();

        // Task<int> ObterQuantidadeAlunosPorTurma();
    }
}
