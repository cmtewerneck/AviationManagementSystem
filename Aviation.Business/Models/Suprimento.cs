using System.Collections.Generic;

namespace AviationManagementApi.Business.Models
{
    public class Suprimento : Entity
    {
        public string Codigo { get; set; } // OPCIONAL (1,30)
        public string PartNumber { get; set; } // OBRIGATÓRIO (1,30)
        public string Nomenclatura { get; set; } // OBRIGATÓRIO (1,50)
        public int Quantidade { get; set; } // OBRIGATÓRIO >= 0
        public string Localizacao { get; set; } // OPCIONAL (1,30)
        public string PartNumberAlternativo { get; set; } // OPCIONAL (1,30)
        public string Aplicacao { get; set; } // OPCIONAL (1,20)
        public string Capitulo { get; set; } // OPCIONAL (1,20)
        public string SerialNumber { get; set; } // OPCIONAL (1,30)
        public string Doc { get; set; } // OPCIONAL (1,20)

        public string Imagem { get; set; } // OPCIONAL

        public IEnumerable<SuprimentoMovimentacao> SuprimentosMovimentacoes { get; set; }
    }
}
