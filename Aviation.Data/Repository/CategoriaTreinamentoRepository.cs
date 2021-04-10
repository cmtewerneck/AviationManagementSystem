using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Data.Repository
{
    public class CategoriaTreinamentoRepository : Repository<CategoriaTreinamento>, ICategoriaTreinamentoRepository
    {
        public CategoriaTreinamentoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<CategoriaTreinamento>> ObterCategoriasTreinamentos()
        {
            return await Db.CategoriasTreinamentos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CategoriaTreinamento> ObterCategoriaTreinamento(Guid id)
        {
            return await Db.CategoriasTreinamentos
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
