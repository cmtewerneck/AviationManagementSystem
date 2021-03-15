using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.EntityFrameworkCore;
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
            return await Db.Turmas.AsNoTracking()
                .Include(p => p.Curso)
                .OrderBy(p => p.Codigo)
                .ToListAsync();
        }
    }
}
