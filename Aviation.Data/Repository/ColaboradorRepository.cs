using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Microsoft.EntityFrameworkCore;
    
namespace AviationManagementApi.Data.Repository
{
    public class ColaboradorRepository : PessoaRepository<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<Colaborador>> ObterColaboradoresPorTipo(TipoColaboradorEnum tipoColaborador)
        {
            return await Db.Colaboradores
                .Where(p => p.TipoColaborador == tipoColaborador)
                .OrderBy(p => p.Nome)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
