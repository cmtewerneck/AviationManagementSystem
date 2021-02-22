using System;

namespace AviationManagementApi.Business.Models
{
    public class ItemOrdemServico : Entity
    {
        public decimal? Custo { get; set; } // OPCIONAL >= 0
        public ItemOrdemServicoStatusEnum Status { get; set; } // OBRIGATÓRIO

        public OrdemServico OrdemServico { get; set; } 
        public Guid OrdemServicoId { get; set; } // OBRIGATÓRIO
        public Servico Servico { get; set; } 
        public Guid ServicoId { get; set; } // OBRIGATÓRIO
    }
}
