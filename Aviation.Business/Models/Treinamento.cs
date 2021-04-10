using System;

namespace AviationManagementApi.Business.Models
{
    public class Treinamento : Entity
    {
        public DateTime DataInicio { get; set; } // OBRIGATÓRIO
        public DateTime? DataTermino { get; set; } // OPCIONAL
        public TipoTreinamentoEnum TipoTreinamento { get; set; } // OBRIGATÓRIO
        public ClassificacaoTreinamentoEnum ClassificacaoTreinamento { get; set; } // OBRIGATÓRIO
        public TipoAeronaveEnum TipoClasse { get; set; } // OBRIGATÓRIO
        public string ModeloAeronave { get; set; } // OBRIGATÓRIO (30)
        public string Instrutor { get; set; } // OBRIGATÓRIO (100)
        public string Numero { get; set; } // OBRIGATÓRIO (50)
        public decimal CargaHoraria { get; set; } // OBRIGATÓRIO

        public Colaborador Tripulante { get; set; } 
        public Guid TripulanteId { get; set; } // OBRIGATÓRIO

        public CategoriaTreinamento Categoria { get; set; }
        public Guid CategoriaId { get; set; } // OBRIGATÓRIO
    }
}
