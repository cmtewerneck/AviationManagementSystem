using System;

namespace AviationManagementApi.Business.Models
{
    public class Rastreador : Entity
    {
        public string Codigo { get; set; } // OBRIGATÓRIO (20)
        public string Modelo { get; set; } // OPCIONAL (50)

        // RELATIONSHIP
        public Aeronave Aeronave{ get; set; } 
        public Guid AeronaveId { get; set; } // OBRIGATÓRIO
    }
}
