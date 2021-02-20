using System;

namespace AviationManagementApi.Api.ViewModels
{
    public class OficioEmitidoViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Numeracao { get; set; }
        public string Mensagem { get; set; }
        public string Responsavel { get; set; }
        public string Destinatario { get; set; }
        public string Assunto { get; set; }

        public string Arquivo { get; set; }
        public string ArquivoUpload { get; set; }
    }
}
