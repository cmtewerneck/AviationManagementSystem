using System;

namespace AviationManagementApi.Api.ViewModels
{
    public class ContasViewModel
    {
        public Guid Id { get; set; }
        public DateTime? DataVencimento { get; set; }
        public string Descricao { get; set; }
        public string CodigoBarras { get; set; }
        public int Situacao { get; set; }
        public string FormaPagamento { get; set; }
    }
}
