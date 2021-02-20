using System;
using System.Collections.Generic;

namespace AviationManagementApi.Api.ViewModels
{
    public class AeronaveViewModel
    {
        public Guid Id { get; set; }
        public string Matricula { get; set; }
        public string Fabricante { get; set; }
        public string Categoria { get; set; }
        public string Modelo { get; set; }
        public string NumeroSerie { get; set; }
        public int? Ano { get; set; }
        public decimal? PesoVazio { get; set; }
        public decimal? PesoBasico { get; set; }
        public decimal? HorasTotais { get; set; }
        public decimal? HorasRestantes { get; set; }
        public int TipoAeronave { get; set; }
        public DateTime? VencimentoCA { get; set; }
        public DateTime? VencimentoCVA { get; set; }
        public DateTime? VencimentoCM { get; set; }
        public DateTime? UltimaPesagem { get; set; }
        public DateTime? ProximaPesagem { get; set; }
        public DateTime? VencimentoReta { get; set; }
        public DateTime? VencimentoCasco { get; set; }
        public string Motor { get; set; }
        public string ModeloMotor { get; set; }
        public string NumeroSerieMotor { get; set; }

        public string ImagemUpload { get; set; }
        public string Imagem { get; set; }

        public IEnumerable<AeronaveAbastecimentoViewModel> AeronavesAbastecimentos { get; set; }
        public IEnumerable<AeronaveTarifaViewModel> AeronavesTarifas { get; set; }
        public IEnumerable<VooAgendadoViewModel> VoosAgendados { get; set; }
        public IEnumerable<VooInstrucaoViewModel> VoosInstrucao { get; set; }
        public IEnumerable<DiarioBordoViewModel> DiariosBordo { get; set; }
        public IEnumerable<OrdemServicoViewModel> OrdensServico { get; set; }
    }
}
