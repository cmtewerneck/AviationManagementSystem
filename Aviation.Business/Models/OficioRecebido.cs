using System;

namespace AviationManagementApi.Business.Models
{
    public class OficioRecebido : Entity
    {
        public DateTime Data { get; set; } // OBRIGATÓRIO
        public string Numeracao { get; set; } // OBRIGATÓRIO (1,20)
        public string Assunto { get; set; } // OBRIGATÓRIO (1,50)
        public string Remetente { get; set; } // OBRIGATÓRIO (1,20)

        public string Arquivo { get; set; } // OPCIONAL
    }
}
