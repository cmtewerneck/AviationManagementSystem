using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class VeiculoMultaViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; } 
        public string AutoInfracao { get; set; } 
        public string Responsavel { get; set; } 
        public string Classificacao { get; set; } 
        public string Descricao { get; set; } 
        public bool Situacao { get; set; }
        public decimal? Valor { get; set; }

        public Guid VeiculoId { get; set; }

        [ScaffoldColumn(false)]
        public string PlacaVeiculo { get; set; }
    }
} 
