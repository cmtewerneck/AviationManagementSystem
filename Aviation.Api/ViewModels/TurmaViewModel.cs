using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class TurmaViewModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public decimal? Inscricao { get; set; } // OPCIONAL >= 0
        public decimal? Mensalidade { get; set; } // OPCIONAL >= 0

        public Guid CursoId { get; set; }
        
        public IEnumerable<AlunoTurmaViewModel> AlunosTurmas { get; set; }

        [ScaffoldColumn(false)]
        public string CodigoCurso { get; set; }

        [ScaffoldColumn(false)]
        public string DescricaoCurso { get; set; }
    }
}
