using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class AlunoTurmaViewModel
    {
        public Guid Id { get; set; }

        public DateTime DataInscricao { get; set; }
        public int SituacaoAluno { get; set; }

        public Guid TurmaId { get; set; }
        public Guid AlunoId { get; set; }

        [ScaffoldColumn(false)]
        public string NomeAluno { get; set; }
        
        [ScaffoldColumn(false)]
        public string CodigoTurma { get; set; }
    }
}
