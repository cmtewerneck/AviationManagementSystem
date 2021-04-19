using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Data.Repository
{
    public class CategoriaVooRepository : Repository<CategoriaVoo>, ICategoriaVooRepository
    {
        public CategoriaVooRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<CategoriaVoo>> ObterCategoriasVoos()
        {
            return await Db.CategoriasVoos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CategoriaVoo> ObterCategoriaVoo(Guid id)
        {
            return await Db.CategoriasVoos
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
