using System;

namespace AviationManagementApi.Api.ViewModels
{
    public class ManualVooViewModel
    {
        public Guid Id { get; set; }
        public string ModeloAeronave { get; set; }
        public DateTime? UltimaRevisao { get; set; }

        public string Arquivo { get; set; }
        public string ArquivoUpload { get; set; }
    }
} 
