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
    public class VooInstrucaoRepository : Repository<VooInstrucao>, IVooInstrucaoRepository
    {
        public VooInstrucaoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoInstrutores()
        {
            return await Db.VoosInstrucoes.AsNoTracking()
                .Include(p => p.Instrutor)
                .OrderBy(p => p.Data)
                .ToListAsync();
        }

        public async Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoInstrutoresAlunosAeronaves()
        {
            return await Db.VoosInstrucoes.AsNoTracking()
                .Include(p => p.Instrutor)
                .Include(p => p.Aluno)
                .Include(p => p.Aeronave)
                .OrderBy(p => p.Data)
                .ToListAsync();
        }

        public async Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoAlunos()
        {
            return await Db.VoosInstrucoes.AsNoTracking()
                .Include(p => p.Aluno)
                .OrderBy(p => p.Data)
                .ToListAsync();
        }

        public async Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoAeronaves()
        {
            return await Db.VoosInstrucoes.AsNoTracking()
                .Include(p => p.Aeronave)
                .OrderBy(p => p.Data)
                .ToListAsync();
        }

        public async Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoPorAeronave(Guid aeronaveId)
        {
            return await Buscar(p => p.AeronaveId == aeronaveId);
        }

        public async Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoPorAluno(Guid alunoId)
        {
            return await Buscar(p => p.AlunoId == alunoId);
        }

        public async Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoPorInstrutor(Guid instrutorId)
        {
            return await Buscar(p => p.InstrutorId == instrutorId);
        }

        public async Task<VooInstrucao> ObterVooInstrucaoAeronave(Guid id)
        {
            return await Db.VoosInstrucoes
                .Include(f => f.Aeronave)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
