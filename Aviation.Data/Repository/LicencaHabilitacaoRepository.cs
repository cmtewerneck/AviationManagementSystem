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
    public class LicencaHabilitacaoRepository : Repository<LicencaHabilitacao>, ILicencaHabilitacaoRepository
    {
        public LicencaHabilitacaoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<LicencaHabilitacao>> ObterLicencasColaboradores()
        {
            return await Db.LicencasHabilitacoes
                .Include(f => f.Colaborador)
                .OrderBy(p => p.Titulo)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<LicencaHabilitacao> ObterLicencaColaborador(Guid id)
        {
            return await Db.LicencasHabilitacoes
                .Include(f => f.Colaborador)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
