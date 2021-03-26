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

        public Guid CursoId { get; set; }
        public IEnumerable<AlunoViewModel> Alunos { get; set; }

        [ScaffoldColumn(false)]
        public string CodigoCurso { get; set; }

        [ScaffoldColumn(false)]
        public string DescricaoCurso { get; set; }
    }
}
