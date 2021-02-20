using System.Collections.Generic;

namespace AviationManagementApi.Business.Models
{
    public class Servico : Entity
    {
        public string Codigo { get; set; } // OBRIGATÓRIO (1,30)
        public string Titulo { get; set; } // OBRIGATÓRIO (1,30)
        public decimal? Custo { get; set; } // OPCIONAL >= 0

        public IEnumerable<ItemOrdemServico> Itens { get; set; }
    }
}