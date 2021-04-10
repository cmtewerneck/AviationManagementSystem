﻿using System;
using System.Collections.Generic;

namespace AviationManagementApi.Api.ViewModels
{
    public class CategoriaTreinamentoViewModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public IEnumerable<TreinamentoViewModel> Treinamentos { get; set; }
    }
} 
