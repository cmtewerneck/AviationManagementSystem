using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class DiariaTripulanteViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataInicio { get; set; } // OBRIGATÓRIO
        public DateTime? DataFim { get; set; } // OPCIONAL
        public decimal Valor { get; set; } // OBRIGATÓRIO > 0
        public string Finalidade { get; set; } // OBRIGATÓRIO (1,500)
        public int Status { get; set; } // OBRIGATÓRIO
        public string FormaPagamento { get; set; } // OBRIGATÓRIO (1,30)

        public Guid TripulanteId { get; set; } // OBRIGATÓRIO

        [ScaffoldColumn(false)]
        public string NomeTripulante { get; set; }
    }
} 
