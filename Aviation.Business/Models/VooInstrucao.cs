using System;

namespace AviationManagementApi.Business.Models
{
    public class VooInstrucao : Entity
    {
        public DateTime Data { get; set; } // OBRIGATÓRIO
        public decimal TempoVoo { get; set; } // OBRIGATÓRIO > 0 EX: 1.5
        public bool Avaliacao { get; set; } // OBRIGATÓRIO
        public string Observacoes { get; set; } // OPCIONAL (1,200)

        public Aluno Aluno { get; set; } // OBRIGATÓRIO
        public Guid AlunoId { get; set; }
        public Aeronave Aeronave { get; set; } // OBRIGATÓRIO
        public Guid AeronaveId { get; set; }
        public Colaborador Instrutor { get; set; } // OBRIGATÓRIO
        public Guid InstrutorId { get; set; }
    }
}
