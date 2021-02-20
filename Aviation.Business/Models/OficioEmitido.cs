using System;

namespace AviationManagementApi.Business.Models
{
    public class OficioEmitido : Entity
    {
        public DateTime Data { get; set; } // OBRIGATÓRIO
        public string Numeracao { get; set; } // OBRIGATÓRIO (1,20)
        public string Mensagem { get; set; } // OBRIGATÓRIO (1,1000)
        public string Responsavel { get; set; } // OPCIONAL (1,20)
        public string Destinatario { get; set; } // OBRIGATÓRIO (1,20)
        public string Assunto { get; set; } // OBRIGATÓRIO (1,50)

        public string Arquivo { get; set; } // OPCIONAL
    }
}
