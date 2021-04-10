using System;
using System.Collections.Generic;

namespace AviationManagementApi.Business.Models
{
    public class Colaborador : Pessoa
    {
        public DateTime? DataNascimento { get; set; } // OPCIONAL
        public DateTime DataAdmissao { get; set; } // OBRIGATÓRIO
        public DateTime? DataDemissao { get; set; } // OPCIONAL
        public DateTime? ValidadeCMA { get; set; } // OPCIONAL
        public TipoColaboradorEnum TipoColaborador { get; set; } // OBRIGATÓRIO
        public string Cargo { get; set; } // OPCIONAL (1,30). AUTO PREENCHIDO CASO SEJA TRIP, MEC, INST
        public string CANAC { get; set; } // OPCIONAL (6). OBRIGATÓRIO SOMENTE SE FOR TRIP, MEC, INST
        public decimal? Salario { get; set; } // OPCIONAL > 0
        public TipoVinculoEnum TipoVinculo { get; set; } // OBRIGATÓRIO. MEI ou CTPS
        public string RG { get; set; } // OBRIGATÓRIO (1,20)
        public string OrgaoEmissor { get; set; } // OPCIONAL (1,20)
        public string TituloEleitor { get; set; } // OPCIONAL (1,30)
        public string NumeroPis { get; set; } // OPCIONAL (1,30)
        public string NumeroCtps { get; set; } // OPCIONAL (1,30)
        public string NumeroCnh { get; set; } // OPCIONAL (1,30)

        public IEnumerable<DiarioBordo> DiariosBordoComandante { get; set; }
        public IEnumerable<DiarioBordo> DiariosBordoCopiloto { get; set; }
        public IEnumerable<DiarioBordo> DiariosBordoMecanico { get; set; }
        public IEnumerable<VeiculoGasto> VeiculosGastos { get; set; }
        public IEnumerable<VooInstrucao> VoosInstrucao { get; set; }
        public IEnumerable<LicencaHabilitacao> LicencasHabilitacoes { get; set; }
        public IEnumerable<Treinamento> Treinamentos { get; set; }
        public IEnumerable<Escala> Escalas { get; set; }
    }
}