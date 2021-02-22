using System;

namespace AviationManagementApi.Business.Models
{
    public class SuprimentoMovimentacao : Entity
    {
        public DateTime Data { get; set; } // OBRIGATÓRIO
        public int Quantidade { get; set; } // OBRIGATÓRIO > 0
        public TipoMovimentacaoEnum TipoMovimentacaoEnum { get; set; } // OBRIGATÓRIO

        public Suprimento Item { get; set; } 
        public Guid ItemId { get; set; } // OBRIGATÓRIO
    }
}
