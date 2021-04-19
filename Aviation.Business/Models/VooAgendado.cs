using System;

namespace AviationManagementApi.Business.Models
{
    public class VooAgendado : Entity
    {
        public string Title { get; set; } // OBRIGATÓRIO (1,30)
        public DateTime Start { get; set; } // OBRIGATÓRIO
        public DateTime End { get; set; } // OBRIGATÓRIO
        public bool AllDay { get; set; } // OBRIGATÓRIO
        public bool Editable { get; set; } // OBRIGATÓRIO
        public bool DurationEditable { get; set; } // OBRIGATÓRIO
        public string BackgroundColor { get; set; } // OBRIGATÓRIO (1,20)
        public string TextColor { get; set; } // OBRIGATÓRIO (1,20)

        public Aeronave Aeronave { get; set; } 
        public Guid AeronaveId { get; set; } // OBRIGATÓRIO

        public CategoriaVoo Categoria { get; set; }
        public Guid CategoriaId { get; set; } // OBRIGATÓRIO
    }
}
