using System;
using System.Collections.Generic;

namespace AviationManagementApi.Api.ViewModels
{
    public class ColaboradorViewModel : PessoaViewModel
    {
        public DateTime? DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }
        public int TipoColaborador { get; set; }
        public string Cargo { get; set; }
        public string CANAC { get; set; }
        public decimal? Salario { get; set; }
        public int TipoVinculo { get; set; }
        public string RG { get; set; }
        public string OrgaoEmissor { get; set; }
        public string TituloEleitor { get; set; }
        public string NumeroPis { get; set; }
        public string NumeroCtps { get; set; }
        public string NumeroCnh { get; set; }

        public IEnumerable<DiarioBordoViewModel> DiariosBordoComandante { get; set; }
        public IEnumerable<DiarioBordoViewModel> DiariosBordoCopiloto { get; set; }
        public IEnumerable<DiarioBordoViewModel> DiariosBordoMecanico { get; set; }
        public IEnumerable<VeiculoGastoViewModel> VeiculosGastos { get; set; }
        public IEnumerable<VooInstrucaoViewModel> VoosInstrucao { get; set; }
    }
}
