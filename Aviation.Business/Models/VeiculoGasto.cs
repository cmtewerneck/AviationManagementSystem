using System;

namespace AviationManagementApi.Business.Models
{
    public class VeiculoGasto : Entity
    {
        public DateTime Data { get; set; } // OBRIGATÓRIO
        public string Descricao { get; set; } // OBRIGATÓRIO (1,50)
        public bool Situacao { get; set; } // OBRIGATÓRIO
        public decimal Valor { get; set; } // OBRIGATÓRIO > 0

        public Colaborador Motorista { get; set; } // OBRIGATÓRIO
        public Guid MotoristaId { get; set; }
        public Veiculo Veiculo { get; set; } // OBRIGATÓRIO
        public Guid VeiculoId { get; set; }
    }
}
