using System;

namespace AviationManagementApi.Business.Models
{
    public class AlunoTurma : Entity
    {
        public DateTime DataInscricao { get; set; } // OBRIGATÓRIO

        public Turma Turma { get; set; } // OBRIGATÓRIO
        public Guid TurmaId { get; set; }
        public Aluno Aluno { get; set; } // OBRIGATÓRIO
        public Guid AlunoId { get; set; }
    }
}