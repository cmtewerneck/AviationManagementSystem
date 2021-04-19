using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class AeronaveMotorViewModel
    {
        public Guid Id { get; set; }
        public string Fabricante { get; set; } // OBRIGATÓRIO (1,50)
        public string Modelo { get; set; } // OBRIGATÓRIO (1,50)
        public string NumeroSerie { get; set; } // OBRIGATÓRIO (1,50)
        public decimal? HorasTotais { get; set; } // OPCIONAL >= 0
        public decimal? CiclosTotais { get; set; } // OPCIONAL >= 0

        public Guid AeronaveId { get; set; }

        [ScaffoldColumn(false)]
        public string MatriculaAeronave { get; set; }
    }
} 
