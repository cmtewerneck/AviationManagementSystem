using System;

namespace AviationManagementApi.Api.ViewModels
{
    public class ContasReceberViewModel : ContasViewModel
    {
        public decimal ValorReceber { get; set; }
        public decimal? ValorRecebido { get; set; }
        public DateTime? DataRecebimento { get; set; }
    }
} 
