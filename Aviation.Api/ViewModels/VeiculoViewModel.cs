using System;
using System.Collections.Generic;

namespace AviationManagementApi.Api.ViewModels
{
    public class VeiculoViewModel
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public string UfPlaca { get; set; }
        public int? Ano { get; set; }
        public bool Proprio { get; set; }
        public int? KmAtual { get; set; }
        public string Modelo { get; set; }
        public string Renavam { get; set; }
        public int TipoCombustivel { get; set; }

        public string Imagem { get; set; }
        public string ImagemUpload { get; set; }

        public IEnumerable<VeiculoMultaViewModel> VeiculoMultas { get; set; }
        public IEnumerable<VeiculoGastoViewModel> VeiculoGastos { get; set; }
    }
}
