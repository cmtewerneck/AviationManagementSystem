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
    public class AeronaveTarifaRepository : Repository<AeronaveTarifa>, IAeronaveTarifaRepository
    {
        public AeronaveTarifaRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<AeronaveTarifa> ObterTarifaAeronave(Guid id)
        {
            return await Db.AeronavesTarifas.AsNoTracking().Include(f => f.Aeronave)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<AeronaveTarifa> ObterTarifaInfraeroAeronave(Guid id)
        {
            return await Db.AeronavesTarifas.AsNoTracking()
                .Include(f => f.Aeronave)
                .Where(p => p.OrgaoEmissorTarifa == OrgaoEmissorTarifaEnum.INFRAERO)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<AeronaveTarifa> ObterTarifaDeceaAeronave(Guid id)
        {
            return await Db.AeronavesTarifas.AsNoTracking().Include(f => f.Aeronave)
                .Where(p => p.OrgaoEmissorTarifa == OrgaoEmissorTarifaEnum.DECEA)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<AeronaveTarifa>> ObterTarifasAeronaves()
        {
            return await Db.AeronavesTarifas
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .OrderBy(p => p.Data)
                .ToListAsync();
        }

        public async Task<IEnumerable<AeronaveTarifa>> ObterTarifasDeceaAeronaves()
        {
            return await Db.AeronavesTarifas
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .Where(p => p.OrgaoEmissorTarifa == OrgaoEmissorTarifaEnum.DECEA)
                .OrderBy(p => p.Data)
                .ToListAsync();
        }

        public async Task<IEnumerable<AeronaveTarifa>> ObterTarifasInfraeroAeronaves()
        {
            return await Db.AeronavesTarifas
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .Where(p => p.OrgaoEmissorTarifa == OrgaoEmissorTarifaEnum.INFRAERO)
                .OrderBy(p => p.Data)
                .ToListAsync();
        }

        public async Task<IEnumerable<AeronaveTarifa>> ObterTarifasPorAeronave(Guid aeronaveId)
        {
            return await Buscar(p => p.AeronaveId == aeronaveId);
        }
    }
}
