using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IVooInstrucaoRepository : IRepository<VooInstrucao>
    {
        Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoPorAeronave(Guid aeronaveId);

        Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoPorAluno(Guid alunoId);

        Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoPorInstrutor(Guid instrutorId);

        Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoAeronaves();
        
        Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoAlunos();

        Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoInstrutores();

        Task<IEnumerable<VooInstrucao>> ObterVoosInstrucaoInstrutoresAlunosAeronaves();
    }
}
