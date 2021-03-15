using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Task<IEnumerable<Curso>> ObterCursosTurmas();
        Task<Curso> ObterCursoTurmas(Guid id);
    }
}
