﻿using System.Collections.Generic;

namespace AviationManagementApi.Business.Models
{
    public class CategoriaVoo : Entity
    {
        public string Codigo { get; set; } // OBRIGATÓRIO (1,50)
        public string Descricao { get; set; } // OBRIGATÓRIO (1,50)

        public IEnumerable<VooAgendado> VoosAgendados { get; set; }
    }
}