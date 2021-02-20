using System;

namespace AviationManagementApi.Business.Models
{
    public class Contas : Entity
    {
        public DateTime? DataVencimento { get; set; } // OPCIONAL
        public string Descricao { get; set; } // OBRIGATÓRIO (1,50)
        public string CodigoBarras { get; set; } // OPCIONAL (1,50)
        public SituacaoContasEnum Situacao { get; set; } // OBRIGATÓRIO
        public string FormaPagamento { get; set; } // OPCIONAL (1,30)
    }
}