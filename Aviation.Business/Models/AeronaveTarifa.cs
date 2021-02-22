using System;

namespace AviationManagementApi.Business.Models
{
    public class AeronaveTarifa : Entity
    {
        public DateTime Data { get; set; } // OBRIGATÓRIO
        public DateTime Vencimento { get; set; } // OBRIGATÓRIO
        public decimal Valor { get; set; } // OBRIGATÓRIO > 0
        public bool Situacao { get; set; } // OBRIGATÓRIO
        public string Numeracao { get; set; } // OBRIGATÓRIO (1,30)
        public OrgaoEmissorTarifaEnum OrgaoEmissorTarifa { get; set; }

        public Aeronave Aeronave { get; set; } 
        public Guid AeronaveId { get; set; } // OBRIGATÓRIO
    }
}
