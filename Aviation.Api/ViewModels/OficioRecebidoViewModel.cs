using System;

namespace AviationManagementApi.Api.ViewModels
{
    public class OficioRecebidoViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Numeracao { get; set; }
        public string Assunto { get; set; }
        public string Remetente { get; set; }

        public string Arquivo { get; set; }
        public string ArquivoUpload { get; set; }
    }
}
