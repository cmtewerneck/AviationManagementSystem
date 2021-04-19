using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class AeronaveDiretrizViewModel
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; } // OBRIGATÓRIO (1,100)
        public string Referencia { get; set; } // OBRIGATÓRIO (1,100)
        public DateTime DataEfetivacao { get; set; } // OBRIGATÓRIO
        public string Descricao { get; set; } // OPCIONAL (1,500)
        public int TipoDiretriz { get; set; } // OBRIGATÓRIO
        public decimal? IntervaloHoras { get; set; } // OPCIONAL >= 0
        public decimal? IntervaloCiclos { get; set; } // OPCIONAL >= 0
        public decimal? IntervaloDias { get; set; } // OPCIONAL >= 0
        public decimal? UltimoCumprimentoHoras { get; set; } // OPCIONAL >= 0
        public decimal? UltimoCumprimentoCiclos { get; set; } // OPCIONAL >= 0
        public DateTime? UltimoCumprimentoData { get; set; } // OPCIONAL
        public string Observacoes { get; set; } // OPCIONAL (1,500)
        public bool Status { get; set; } // OBRIGATÓRIO

        public Guid AeronaveId { get; set; }

        [ScaffoldColumn(false)]
        public string MatriculaAeronave { get; set; }

        [ScaffoldColumn(false)]
        public decimal HorasTotaisAeronave { get; set; }
    }
} 
