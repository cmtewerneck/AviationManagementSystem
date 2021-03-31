using System;

namespace AviationManagementApi.Business.Models
{
    public class LicencaHabilitacao : Entity
    {
        public string Titulo { get; set; } // OBRIGATÓRIO (1,20)
        public DateTime Validade { get; set; } // OBRIGATÓRIO

        public Colaborador Colaborador { get; set; } 
        public Guid ColaboradorId { get; set; } // OBRIGATÓRIO
    }
}
