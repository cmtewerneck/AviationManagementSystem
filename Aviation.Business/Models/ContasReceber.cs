using System;

namespace AviationManagementApi.Business.Models
{
    public class ContasReceber : Contas
    {
        public decimal ValorReceber { get; set; } // OBRIGATÓRIO > 0
        public decimal? ValorRecebido { get; set; } // OPCIONAL > 0
        public DateTime? DataRecebimento { get; set; } // OPCIONAL
    }
}
