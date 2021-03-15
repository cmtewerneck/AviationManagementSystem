using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Data.Repository
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<Servico> ObterServicoOrdensServico(Guid id)
        {
            return await Db.Servicos
                .Include(c => c.Itens)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
