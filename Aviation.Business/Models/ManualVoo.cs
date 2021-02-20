using System;

namespace AviationManagementApi.Business.Models
{
    public class ManualVoo: Entity
    {
        public string ModeloAeronave { get; set; } // OBRIGATÓRIO (1,20)
        public DateTime? UltimaRevisao { get; set; } // OPCIONAL

        public string Arquivo { get; set; } // OPCIONAL
    }
}
