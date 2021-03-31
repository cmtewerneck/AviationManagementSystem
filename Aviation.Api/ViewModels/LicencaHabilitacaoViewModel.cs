using AviationManagementApi.Api.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class LicencaHabilitacaoViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Validade { get; set; }

        public Guid ColaboradorId { get; set; }

        [ScaffoldColumn(false)]
        public string NomeColaborador { get; set; }
    }
} 
