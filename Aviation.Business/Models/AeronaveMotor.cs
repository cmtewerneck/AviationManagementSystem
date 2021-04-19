using System;

namespace AviationManagementApi.Business.Models
{
    public class AeronaveMotor : Entity
    {
        public string Fabricante { get; set; } // OBRIGATÓRIO (1,50)
        public string Modelo { get; set; } // OBRIGATÓRIO (1,50)
        public string NumeroSerie { get; set; } // OBRIGATÓRIO (1,50)
        public decimal? HorasTotais { get; set; } // OPCIONAL >= 0
        public decimal? CiclosTotais { get; set; } // OPCIONAL >= 0

        public Aeronave Aeronave { get; set; } 
        public Guid AeronaveId { get; set; } // OBRIGATÓRIO
    }
}
