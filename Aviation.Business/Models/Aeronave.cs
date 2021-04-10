using System;
using System.Collections.Generic;

namespace AviationManagementApi.Business.Models
{
    public class Aeronave : Entity
    {
        public string Matricula { get; set; } // OBRIGATÓRIO (5)
        public string Fabricante { get; set; } // OBRIGATÓRIO (1,50)
        public string Categoria { get; set; } // OBRIGATÓRIO (1,20)
        public string Modelo { get; set; } // OBRIGATÓRIO (1,30)
        public string NumeroSerie { get; set; } // OPCIONAL (1,20)
        public int? Ano { get; set; } // OPCIONAL
        public decimal? PesoVazio { get; set; } // OPCIONAL > 0
        public decimal? PesoBasico { get; set; } // OPCIONAL > 0
        public decimal? HorasTotais { get; set; } // OPCIONAL >= 0
        public decimal? HorasRestantes { get; set; } // OPCIONAL 
        public TipoAeronaveEnum TipoAeronave { get; set; } // OBRIGATÓRIO
        public DateTime? VencimentoCA { get; set; } // OPCIONAL
        public DateTime? VencimentoCVA { get; set; } // OPCIONAL
        public DateTime? VencimentoCM { get; set; } // OPCIONAL
        public DateTime? UltimaPesagem { get; set; } // OPCIONAL
        public DateTime? ProximaPesagem { get; set; } // OPCIONAL
        public DateTime? VencimentoReta { get; set; } // OPCIONAL
        public DateTime? VencimentoCasco { get; set; } // OPCIONAL
        public string Motor { get; set; } // OPCIONAL (1,30)
        public string ModeloMotor { get; set; } // OPCIONAL (1,30)
        public string NumeroSerieMotor { get; set; } // OPCIONAL (1,30)
        public bool Ativo { get; set; } // OBRIGATÓRIO
        public bool Situacao { get; set; } // OBRIGATÓRIO

        public string Imagem { get; set; } // OPCIONAL

        // RELATIONSHIP
        public IEnumerable<AeronaveAbastecimento> AeronavesAbastecimentos { get; set; }
        public IEnumerable<AeronaveTarifa> AeronaveTarifas { get; set; }
        public IEnumerable<VooAgendado> VoosAgendados { get; set; }
        public IEnumerable<VooInstrucao> VoosInstrucao { get; set; }
        public IEnumerable<DiarioBordo> DiariosBordo { get; set; }
        public IEnumerable<OrdemServico> OrdensServico { get; set; }
        public Rastreador Rastreador { get; set; }
    }
}
