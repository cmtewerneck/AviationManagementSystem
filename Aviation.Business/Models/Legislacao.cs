using System;

namespace AviationManagementApi.Business.Models
{
    public class Legislacao: Entity
    {
        public string Titulo { get; set; } // OBRIGATÓRIO (1,50)
        public TipoLegislacaoEnum TipoLegislacao { get; set; } // OBRIGATÓRIO
        public int Numero { get; set; } // OBRIGATÓRIO
        public int? Emenda { get; set; } // OPCIONAL
        public DateTime? DataEmenda { get; set; } // OPCIONAL

        public string Arquivo { get; set; } // OPCIOINAL
    }
}
