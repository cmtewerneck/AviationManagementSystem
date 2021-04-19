using System;

namespace AviationManagementApi.Business.Models
{
    public class DiariaTripulante : Entity
    {
        public DateTime DataInicio { get; set; } // OBRIGATÓRIO
        public DateTime? DataFim { get; set; } // OPCIONAL
        public decimal Valor { get; set; } // OBRIGATÓRIO > 0
        public string Finalidade { get; set; } // OBRIGATÓRIO (1,500)
        public SituacaoContasEnum Status { get; set; } // OBRIGATÓRIO
        public string FormaPagamento { get; set; } // OPCIONAL (1,30)

        public Colaborador Tripulante { get; set; }
        public Guid TripulanteId { get; set; } // OBRIGATÓRIO
    }
}
