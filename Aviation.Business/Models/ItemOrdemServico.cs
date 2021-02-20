using System;

namespace AviationManagementApi.Business.Models
{
    public class ItemOrdemServico : Entity
    {
        public decimal? Custo { get; set; } // OPCIONAL >= 0
        public ItemOrdemServicoStatusEnum Status { get; set; } // OBRIGATÓRIO

        public OrdemServico OrdemServico { get; set; } // OBRIGATÓRIO
        public Guid OrdemServicoId { get; set; }
        public Servico Servico { get; set; } // OBRIGATÓRIO
        public Guid ServicoId { get; set; }
    }
}
