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
    public class AeronaveMotorRepository : Repository<AeronaveMotor>, IAeronaveMotorRepository
    {
        public AeronaveMotorRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<AeronaveMotor> ObterMotorAeronave(Guid id)
        {
            return await Db.AeronavesMotores
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<AeronaveMotor>> ObterMotoresAeronaves()
        {
            return await Db.AeronavesMotores
                .AsNoTracking()
                .Include(f => f.Aeronave)
                .OrderBy(p => p.NumeroSerie)
                .ToListAsync();
        }

        public async Task<IEnumerable<AeronaveMotor>> ObterMotoresPorAeronave(Guid aeronaveId)
        {
            return await Buscar(p => p.AeronaveId == aeronaveId);
        }
    }
}
