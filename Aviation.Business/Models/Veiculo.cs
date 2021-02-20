using System.Collections.Generic;

namespace AviationManagementApi.Business.Models
{
    public class Veiculo : Entity
    {
        public string Placa { get; set; } // OBRIGATÓRIO (7,10)
        public string UfPlaca { get; set; } // OBRIGATÓRIO (2)
        public int? Ano { get; set; } // OPCIONAL > 1950 < 2021
        public bool Proprio { get; set; } // OBRIGATÓRIO
        public int? KmAtual { get; set; } // OPCIONAL >= 0
        public string Modelo { get; set; } // OBRIGATÓRIO (1,30)
        public string Renavam { get; set; } // OBRIGATÓRIO (1,30)
        public TipoCombustivelEnum TipoCombustivel { get; set; } // OBRIGATÓRIO

        public string Imagem { get; set; } // OPCIONAL

        public IEnumerable<VeiculoMulta> VeiculoMultas { get; set; }
        public IEnumerable<VeiculoGasto> VeiculosGastos { get; set; }
    }
}
