using System;

namespace AviationManagementApi.Business.Models
{
    public class AeronaveDocumento : Entity
    {
        public string Titulo { get; set; } // OBRIGATÓRIO (1,50)
        public DateTime? DataEmissao { get; set; } // OPCIONAL
        public DateTime DataValidade { get; set; } // OBRIGATÓRIO

        public string Arquivo { get; set; } // OPCIONAL

        public Aeronave Aeronave { get; set; } 
        public Guid AeronaveId { get; set; } // OBRIGATÓRIO
    }
}
