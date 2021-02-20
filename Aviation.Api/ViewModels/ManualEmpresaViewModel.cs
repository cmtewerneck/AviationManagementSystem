using System;

namespace AviationManagementApi.Api.ViewModels
{
    public class ManualEmpresaViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public int RevisaoAtual { get; set; }
        public DateTime DataRevisao { get; set; }
        public int? RevisaoAnalise { get; set; }

        public string Arquivo { get; set; }
        public string ArquivoUpload { get; set; }
    }
} 
