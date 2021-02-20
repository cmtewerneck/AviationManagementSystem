using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class ItemOrdemServicoViewModel
    {
        public Guid Id { get; set; }
        public decimal? Custo { get; set; }
        public int Status { get; set; }

        public Guid OrdemServicoId { get; set; }
        public Guid ServicoId { get; set; }

        [ScaffoldColumn(false)]
        public string NumeroOrdem { get; set; }

        [ScaffoldColumn(false)]
        public string CodigoServico { get; set; }
    }
}