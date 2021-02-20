using System;

namespace AviationManagementApi.Api.ViewModels
{
    public class LegislacaoViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public int TipoLegislacao { get; set; }
        public int Numero { get; set; } 
        public int? Emenda { get; set; }
        public DateTime? DataEmenda { get; set; }

        public string Arquivo { get; set; }
        public string ArquivoUpload { get; set; }
    }
} 
