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
    public class TreinamentoRepository : Repository<Treinamento>, ITreinamentoRepository
    {
        public TreinamentoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<Treinamento>> ObterTreinamentosColaboradoresCategorias()
        {
            return await Db.Treinamentos
                .AsNoTracking()
                .Include(f => f.Tripulante)
                .Include(f => f.Categoria)
                .OrderBy(p => p.DataInicio)
                .ToListAsync();
        }

        public async Task<Treinamento> ObterTreinamentoColaboradorCategoria(Guid id)
        {
            return await Db.Treinamentos
                .Include(c => c.Tripulante)
                .Include(c => c.Categoria)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
