using System;
using System.Collections.Generic;

namespace AviationManagementApi.Business.Models
{
    public class Aluno : Pessoa
    {
        public string RG { get; set; } // OBRIGATÓRIO (1,20)
        public string CANAC { get; set; } // OPCIONAL (6)
        public decimal TotalVoado { get; set; } // OBRIGATÓRIO >= 0 EX: VOOU 4,5
        public decimal Saldo { get; set; } // OBRIGATÓRIO EX: POSSUI 10.5 DE SALDO
        public DateTime DataNascimento { get; set; } // OBRIGATÓRIO
        public DateTime? ValidadeCMA { get; set; } // OPCIONAL

        public IEnumerable<VooInstrucao> VoosInstrucao { get; set; }
        public IEnumerable<AlunoTurma> AlunosTurmas { get; set; }
    }
}
