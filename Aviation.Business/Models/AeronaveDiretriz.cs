using System;

namespace AviationManagementApi.Business.Models
{
    public class AeronaveDiretriz : Entity
    {
        public string Titulo { get; set; } // OBRIGATÓRIO (1,100)
        public string Referencia { get; set; } // OBRIGATÓRIO (1,100)
        public DateTime DataEfetivacao { get; set; } // OBRIGATÓRIO
        public string Descricao { get; set; } // OPCIONAL (1,500)
        public TipoDiretrizEnum TipoDiretriz { get; set; } // OBRIGATÓRIO
        public decimal? IntervaloHoras { get; set; } // OPCIONAL >= 0
        public decimal? IntervaloCiclos { get; set; } // OPCIONAL >= 0
        public decimal? IntervaloDias { get; set; } // OPCIONAL >= 0
        public decimal? UltimoCumprimentoHoras { get; set; } // OPCIONAL >= 0
        public decimal? UltimoCumprimentoCiclos { get; set; } // OPCIONAL >= 0
        public DateTime? UltimoCumprimentoData { get; set; } // OPCIONAL
        public string Observacoes { get; set; } // OPCIONAL (1,500)
        public bool Status { get; set; } // OBRIGATÓRIO

        public Aeronave Aeronave { get; set; } 
        public Guid AeronaveId { get; set; } // OBRIGATÓRIO
    }
}
