using AviationManagementApi.Api.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class VeiculoGastoViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; } 
        public string Descricao { get; set; } 
        public bool Situacao { get; set; } 
        [Moeda]
        public decimal Valor { get; set; } 

        public Guid MotoristaId { get; set; }
        public Guid VeiculoId { get; set; }

        [ScaffoldColumn(false)]
        public string PlacaVeiculo { get; set; }

        [ScaffoldColumn(false)]
        public string NomeMotorista { get; set; }
    }
} 
