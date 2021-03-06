﻿using System;
using System.Collections.Generic;

namespace AviationManagementApi.Business.Models
{
    public class Turma : Entity
    {
        public string Codigo { get; set; } // OBRIGATÓRIO (1,30)
        public DateTime DataInicio { get; set; } // OBRIGATÓRIO
        public DateTime? DataTermino { get; set; } // OPCIONAL
        public decimal? Inscricao { get; set; } // OPCIONAL >= 0
        public decimal? Mensalidade { get; set; } // OPCIONAL >= 0

        public Curso Curso { get; set; } 
        public Guid CursoId { get; set; } // OBRIGATÓRIO
        public IEnumerable<AlunoTurma> AlunosTurmas { get; set; }
    }
}