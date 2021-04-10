using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class TreinamentoViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataInicio { get; set; } // OBRIGATÓRIO
        public DateTime? DataTermino { get; set; } // OPCIONAL
        public int ClassificacaoTreinamento { get; set; } // OBRIGATÓRIO
        public int TipoTreinamento { get; set; } // OBRIGATÓRIO
        public int TipoClasse { get; set; } // OBRIGATÓRIO
        public string ModeloAeronave { get; set; } // OPCIONAL (30)
        public string Instrutor { get; set; } // OBRIGATÓRIO (100)
        public string Numero { get; set; } // OBRIGATÓRIO (50)
        public decimal CargaHoraria { get; set; } // OBRIGATÓRIO

        public Guid TripulanteId { get; set; } // OBRIGATÓRIO
        public Guid CategoriaId { get; set; } // OBRIGATÓRIO

        [ScaffoldColumn(false)]
        public string NomeTripulante{ get; set; }

        [ScaffoldColumn(false)]
        public string DescricaoCategoria { get; set; }
    }
} 
