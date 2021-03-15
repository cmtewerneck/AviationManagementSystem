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
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<Curso>> ObterCursosTurmas()
        {
            return await Db.Cursos.AsNoTracking()
                .Include(f => f.Turmas)
                .OrderBy(p => p.Codigo)
                .ToListAsync();
        }

        public async Task<Curso> ObterCursoTurmas(Guid id)
        {
            return await Db.Cursos
                .Include(c => c.Turmas)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
