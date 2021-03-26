using System;

namespace AviationManagementApi.Business.Models
{
    public class DiarioBordo : Entity
    {
        public DateTime Data { get; set; } // OBRIGATÓRIO
        public string Base { get; set; } // OPCIONAL (1,20)
        public string De { get; set; } // OBRIGATÓRIO (4)
        public string Para { get; set; } // OBRIGATÓRIO (4)
        public DateTime HoraAcionamento { get; set; } // OBRIGATÓRIO
        public DateTime? HoraDecolagem { get; set; } // OPCIONAL
        public DateTime? HoraPouso { get; set; } // OPCIONAL
        public DateTime HoraCorte { get; set; } // OBRIGATÓRIO
        public DateTime? TotalDiurno { get; set; } // OPCIONAL
        public DateTime? TotalNoturno { get; set; } // OPCIONAL 
        public DateTime? TotalIfr { get; set; } // OPCIONAL
        public DateTime? TotalNavegacao { get; set; } // OPCIONAL
        public decimal TotalDecimal { get; set; } // OBRIGATÓRIO EX: 1.5
        public decimal? TotalDecPouso { get; set; } // OPCIONAL >= 0
        public decimal TotalAcionamentoCorte { get; set; } // OBRIGATÓRIO > 0
        public int Pousos { get; set; } // OBRIGATÓRIO >= 0
        public int Pob { get; set; } // OBRIGATÓRIO > 0
        public int CombustivelDecolagem { get; set; } // OBRIGATÓRIO > 0
        public NaturezaVooEnum NaturezaVoo { get; set; } // OBRIGATÓRIO
        public string PreVooResponsavel { get; set; } // OBRIGATÓRIO (1,20)
        public string PosVooResponsavel { get; set; } // OBRIGATÓRIO (1,20)
        public string Observacoes { get; set; } // OPCIONAL (1,300)
        public string Discrepancias { get; set; } // OPCIONAL (1,300)
        public string AcoesCorretivas { get; set; } // OPCIONAL (1,300)

        public Aeronave Aeronave { get; set; } 
        public Guid AeronaveId { get; set; } // OBRIGATÓRIO
        public Colaborador Comandante { get; set; } 
        public Guid ComandanteId { get; set; } // OBRIGATÓRIO
        public Colaborador Copiloto { get; set; } 
        public Guid CopilotoId { get; set; } // OPCIONAL
        public Colaborador MecanicoResponsavel { get; set; } 
        public Guid MecanicoResponsavelId { get; set; } // OBRIGATÓRIO
    }
}
