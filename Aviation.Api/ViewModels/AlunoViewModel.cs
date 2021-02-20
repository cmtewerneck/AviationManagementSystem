using System;
using System.Collections.Generic;

namespace AviationManagementApi.Api.ViewModels
{
    public class AlunoViewModel : PessoaViewModel
    {
        public string RG { get; set; }
        public string CANAC { get; set; }
        public decimal TotalVoado { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime? ValidadeCMA { get; set; }

        public IEnumerable<VooInstrucaoViewModel> VoosInstrucao { get; set; }
        public IEnumerable<AlunoTurmaViewModel> AlunosTurmas { get; set; }
    }
}
