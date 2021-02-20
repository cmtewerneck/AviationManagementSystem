using System;

namespace AviationManagementApi.Business.Models
{
    public class ManualEmpresa : Entity
    {
        public string Descricao { get; set; } // OBRIGATÓRIO (1,50)
        public string Sigla { get; set; } // OBRIGATÓRIO (1,10)
        public int RevisaoAtual { get; set; } // OBRIGATÓRIO >= 0
        public DateTime DataRevisao { get; set; } // OBRIGATÓRIO
        public int? RevisaoAnalise { get; set; } // OPCIONAL

        public string Arquivo { get; set; } // OPCIONAL
    }
}
