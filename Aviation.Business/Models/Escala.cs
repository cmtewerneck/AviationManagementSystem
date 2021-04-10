using System;

namespace AviationManagementApi.Business.Models
{
    public class Escala : Entity
    {
        public DateTime Data { get; set; } // OBRIGATÓRIO
        public StatusEscalaEnum Status { get; set; } // OBRIGATÓRIO

        // RELATIONSHIP
        public Colaborador Tripulante { get; set; }
        public Guid TripulanteId { get; set; } // OBRIGATÓRIO
    }
}
