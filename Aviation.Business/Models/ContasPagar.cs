using System;

namespace AviationManagementApi.Business.Models
{
    public class ContasPagar : Contas
    {
        public decimal ValorPagar { get; set; } // OBRIGATÓRIO > 0
        public decimal? ValorPago { get; set; } // OPCIONAL > 0
        public DateTime? DataPagamento { get; set; } // OPCIONAL
    }
}
