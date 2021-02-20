using System;
using System.Collections.Generic;

namespace AviationManagementApi.Api.ViewModels
{
    public class SuprimentoViewModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string PartNumber { get; set; }
        public string Nomenclatura { get; set; }
        public int Quantidade { get; set; }
        public string Localizacao { get; set; }
        public string PartNumberAlternativo { get; set; }
        public string Aplicacao { get; set; }
        public string Capitulo { get; set; }
        public string SerialNumber { get; set; }
        public string Doc { get; set; }

        public string Imagem { get; set; }
        public string ImagemUpload { get; set; }

        public IEnumerable<SuprimentoMovimentacaoViewModel> SuprimentosMovimentacoes { get; set; }
    }
}
