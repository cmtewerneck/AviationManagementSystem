using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class OrdemServicoViewModel
    {
        public Guid Id { get; set; }
        public string NumeroOrdem { get; set; }
        public string Tipo { get; set; }
        public string Ttsn { get; set; }
        public string TcsnPousos { get; set; }
        public DateTime DataAbertura { get; set; }
        public string TtsnMotor { get; set; }
        public string TcsnCiclos { get; set; }
        public DateTime? DataFechamento { get; set; }
        public string RequisicaoMateriais { get; set; }
        public string RealizadoPor { get; set; }
        public string RealizadoPorAnac { get; set; }
        public DateTime? DataRealizacao { get; set; }
        public string InspecionadoPor { get; set; }
        public string InspecionadoPorAnac { get; set; }
        public DateTime? DataInspecao { get; set; }

        public Guid AeronaveId { get; set; }
        public IEnumerable<ItemOrdemServicoViewModel> Itens { get; set; }

        [ScaffoldColumn(false)]
        public string MatriculaAeronave { get; set; }
    }
}