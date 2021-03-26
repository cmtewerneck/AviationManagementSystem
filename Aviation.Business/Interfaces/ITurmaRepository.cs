using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Task<IEnumerable<Turma>> ObterTurmasCursos();

        Task<IEnumerable<Turma>> ObterTurmasCursoAlunos();

        Task<Turma> ObterTurmaCurso(Guid id);

        Task<Turma> ObterTurmaCursoAlunos(Guid id);
    }
}