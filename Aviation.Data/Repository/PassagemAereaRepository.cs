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
    public class PassagemAereaRepository : Repository<PassagemAerea>, IPassagemAereaRepository
    {
        public PassagemAereaRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<PassagemAerea>> ObterPassagensAereas()
        {
            return await Db.PassagensAereas
                .AsNoTracking()
                .OrderBy(p => p.DataVoo)
                .ToListAsync();
        }

        public async Task<IEnumerable<PassagemAerea>> ObterPassagensAereasColaborador()
        {
            return await Db.PassagensAereas
                .AsNoTracking()
                .Include(c => c.Colaborador)
                .OrderBy(p => p.DataVoo)
                .ToListAsync();
        }

        public async Task<PassagemAerea> ObterPassagemAerea(Guid id)
        {
            return await Db.PassagensAereas
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<PassagemAerea> ObterPassagemAereaColaborador(Guid id)
        {
            return await Db.PassagensAereas
                .AsNoTracking()
                .Include(c => c.Colaborador)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
