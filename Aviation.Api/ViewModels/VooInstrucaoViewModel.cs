using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class VooInstrucaoViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public double TempoVoo { get; set; }
        public bool Avaliacao { get; set; } 
        public string Observacoes { get; set; } 

        public Guid AlunoId { get; set; }
        public Guid AeronaveId { get; set; }
        public Guid InstrutorId { get; set; }

        [ScaffoldColumn(false)]
        public string NomeAluno { get; set; }

        [ScaffoldColumn(false)]
        public string NomeInstrutor { get; set; }

        [ScaffoldColumn(false)]
        public string MatriculaAeronave { get; set; }
    }
} 
