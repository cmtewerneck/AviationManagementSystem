using System;

namespace AviationManagementApi.Api.ViewModels
{
    public class ContasPagarViewModel : ContasViewModel
    {
        public decimal ValorPagar { get; set; }
        public decimal? ValorPago { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
} 
