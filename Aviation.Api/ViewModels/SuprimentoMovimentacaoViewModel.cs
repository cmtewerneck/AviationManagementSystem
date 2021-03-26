using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class SuprimentoMovimentacaoViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public int TipoMovimentacaoEnum { get; set; }

        public Guid ItemId { get; set; }

        [ScaffoldColumn(false)]
        public string CodigoItem { get; set; }

        [ScaffoldColumn(false)]
        public string NomenclaturaItem { get; set; }
    }
} 
