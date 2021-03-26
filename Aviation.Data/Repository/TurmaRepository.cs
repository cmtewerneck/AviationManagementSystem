using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Data.Repository
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<Turma>> ObterTurmasCursos()
        {
            return await Db.Turmas
                .AsNoTracking()
                .Include(p => p.Curso)
                .OrderBy(p => p.Codigo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Turma>> ObterTurmasCursoAlunos()
        {
            return await Db.Turmas
                .AsNoTracking()
                .Include(c => c.Curso)
                .Include(at => at.AlunosTurmas).ThenInclude(a => a.Aluno)
                .OrderBy(order => order.Codigo)
                .ToListAsync();
        }

        public async Task<Turma> ObterTurmaCurso(Guid id)
        {
            return await Db.Turmas
                .AsNoTracking()
                .Include(f => f.Curso)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Turma> ObterTurmaCursoAlunos(Guid id)
        {
            return await Db.Turmas
                .Include(c => c.Curso)
                .Include(c => c.AlunosTurmas).ThenInclude(a => a.Aluno)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
