using System;

namespace AviationManagementApi.Business.Models
{
    public class VeiculoMulta : Entity
    {
        public DateTime Data { get; set; } // OBRIGATÓRIO
        public string AutoInfracao { get; set; } // OBRIGATÓRIO (1,30)
        public string Responsavel { get; set; } // OPCIONAL (1,30)
        public string Classificacao { get; set; } // OPCIONAL (1,30)
        public string Descricao { get; set; } // OBRIGATÓRIO (1,50)
        public bool Situacao { get; set; } // OBRIGATÓRIO
        public decimal? Valor { get; set; } // OPCIONAL > 0

        public Veiculo Veiculo { get; set; } 
        public Guid VeiculoId { get; set; } // OBRIGATÓRIO
    }
}
