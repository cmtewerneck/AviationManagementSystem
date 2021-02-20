using AviationManagementApi.Api.Extensions;
using System;
using System.Collections.Generic;

namespace AviationManagementApi.Api.ViewModels
{
    public class ServicoViewModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        [Moeda]
        public decimal? Custo { get; set; }

        public IEnumerable<ItemOrdemServicoViewModel> Itens { get; set; }
    }
}