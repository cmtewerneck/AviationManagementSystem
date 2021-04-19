using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class PassagemAereaViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataCompra { get; set; } // OBRIGATÓRIO
        public DateTime DataVoo { get; set; } // OBRIGATÓRIO
        public decimal Valor { get; set; } // OBRIGATÓRIO > 0
        public string Empresa { get; set; } // OBRIGATÓRIO (1,100)
        public string Origem { get; set; } // OBRIGATÓRIO (1,100)
        public string Destino { get; set; } // OBRIGATÓRIO (1,100)
        public string FormaPagamento { get; set; } // OPCIONAL (1,30)
        public string Assento { get; set; } // OBRIGATÓRIO (1,30)
        public string Localizador { get; set; } // OPCIONAL (1,30)

        public Guid ColaboradorId { get; set; } // OBRIGATÓRIO (tripulante, instrutor ou mecânico)

        [ScaffoldColumn(false)]
        public string NomeColaborador { get; set; }
    }
} 
