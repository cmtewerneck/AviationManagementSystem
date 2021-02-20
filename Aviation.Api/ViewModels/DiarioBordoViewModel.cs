using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class DiarioBordoViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Base { get; set; }
        public string De { get; set; }
        public string Para { get; set; }
        public DateTime HoraAcionamento { get; set; }
        public DateTime? HoraDecolagem { get; set; }
        public DateTime? HoraPouso { get; set; }
        public DateTime HoraCorte { get; set; }
        public DateTime? TotalDiurno { get; set; }
        public DateTime? TotalNoturno { get; set; }
        public DateTime? TotalIfr { get; set; }
        public DateTime? TotalNavegacao { get; set; }
        public decimal TotalDecimal { get; set; }
        public decimal? TotalDecPouso { get; set; }
        public decimal TotalAcionamentoCorte { get; set; }
        public int Pousos { get; set; }
        public int Pob { get; set; }
        public int CombustivelDecolagem { get; set; }
        public int NaturezaVoo { get; set; }
        public string PreVooResponsavel { get; set; }
        public string PosVooResponsavel { get; set; }
        public string Observacoes { get; set; }
        public string Discrepancias { get; set; }
        public string AcoesCorretivas { get; set; }

        public Guid AeronaveId { get; set; }
        public Guid ComandanteId { get; set; }
        public Guid? CopilotoId { get; set; }
        public Guid? MecanicoResponsavelId { get; set; }

        [ScaffoldColumn(false)]
        public string MatriculaAeronave { get; set; }

        [ScaffoldColumn(false)]
        public string NomeComandante { get; set; }

        [ScaffoldColumn(false)]
        public string NomeCopiloto { get; set; }

        [ScaffoldColumn(false)]
        public string NomeMecanico { get; set; }
    }
} 
