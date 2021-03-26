using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Data.Repository
{
    public class AlunoRepository : PessoaRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<Aluno>> ObterAlunosTurmasCurso()
        {
            return await Db.Alunos
                .AsNoTracking()
                .Include(at => at.AlunosTurmas).ThenInclude(t => t.Turma)
                .OrderBy(order => order.Nome)
                .ToListAsync();
        }
    }
}
