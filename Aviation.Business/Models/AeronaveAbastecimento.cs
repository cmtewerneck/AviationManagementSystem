using System;

namespace AviationManagementApi.Business.Models
{
    public class AeronaveAbastecimento : Entity
    {
        public DateTime Data { get; set; } // OBRIGATÓRIO
        public int Litros { get; set; } // OBRIGATÓRIO > 0
        public string Local { get; set; } // OBRIGATÓRIO (1,20)
        public string Cupom { get; set; } // OBRIGATÓRIO (1,20)
        public string NotaFiscal { get; set; } // OPCIONAL (1,20)
        public string Fornecedora { get; set; } // OBRIGATÓRIO (1,20)
        public string Responsavel { get; set; } // OBRIGATÓRIO (1,20)
        public decimal? Valor { get; set; } // OPCIONAL > 0
        public string Observacoes { get; set; } // OPCIONAL (1,100)

        public string Comprovante { get; set; } // OPCIONAL

        public Aeronave Aeronave { get; set; } // OBRIGATÓRIO
        public Guid AeronaveId { get; set; }
    }
}
