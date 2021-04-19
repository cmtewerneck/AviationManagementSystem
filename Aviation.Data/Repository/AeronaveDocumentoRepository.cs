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
    public class AeronaveDocumentoRepository : Repository<AeronaveDocumento>, IAeronaveDocumentoRepository
    {
        public AeronaveDocumentoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<AeronaveDocumento> ObterDocumentoAeronave(Guid id)
        {
            return await Db.AeronavesDocumentos
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<AeronaveDocumento>> ObterDocumentosAeronaves()
        {
            return await Db.AeronavesDocumentos
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .OrderBy(p => p.Aeronave)
                .ToListAsync();
        }

        public async Task<IEnumerable<AeronaveDocumento>> ObterDocumentosPorAeronave(Guid aeronaveId)
        {
            return await Buscar(p => p.AeronaveId == aeronaveId);
        }
    }
}
