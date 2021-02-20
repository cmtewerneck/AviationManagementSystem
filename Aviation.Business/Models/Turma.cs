using System;
using System.Collections.Generic;

namespace AviationManagementApi.Business.Models
{
    public class Turma : Entity
    {
        public string Codigo { get; set; } // OBRIGATÓRIO (1,30)
        public DateTime DataInicio { get; set; } // OBRIGATÓRIO
        public DateTime? DataTermino { get; set; } // OPCIONAL

        public Curso Curso { get; set; } // OBRIGATÓRIO
        public Guid CursoId { get; set; }
        public IEnumerable<AlunoTurma> AlunosTurmas { get; set; }
    }
}