using System;
using System.Collections.Generic;

namespace AviationManagementApi.Business.Models
{
    public class OrdemServico : Entity
    {
        public string NumeroOrdem { get; set; } // OBRIGATÓRIO (1,20)
        public string Tipo { get; set; } // OPCIONAL (1,20)
        public string Ttsn { get; set; } // OPCIONAL (1,20)
        public string TcsnPousos { get; set; } // OPCIONAL (1,20)
        public DateTime DataAbertura { get; set; } // OBRIGATÓRIO
        public string TtsnMotor { get; set; } // OPCIONAL (1,20)
        public string TcsnCiclos { get; set; } // OPCIONAL (1,20)
        public DateTime? DataFechamento { get; set; } // OPCIONAL
        public string RequisicaoMateriais { get; set; } // OPCIONAL (1,300)
        public string RealizadoPor { get; set; } // OPCIONAL (1,20)
        public string RealizadoPorAnac { get; set; } // OPCIONAL (6)
        public DateTime? DataRealizacao { get; set; } // OPCIONAL
        public string InspecionadoPor { get; set; } // OPCIONAL (1,20)
        public string InspecionadoPorAnac { get; set; } // OPCIONAL (6)
        public DateTime? DataInspecao { get; set; } // OPCIONAL

        public Aeronave Aeronave { get; set; } // OBRIGATÓRIO
        public Guid AeronaveId { get; set; }
        public IEnumerable<ItemOrdemServico> Itens { get; set; }
    }
}
