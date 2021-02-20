using System.Collections.Generic;

namespace AviationManagementApi.Business.Models
{
    public class Fornecedor : Pessoa
    {
        public Endereco Endereco { get; set; } // OBRIGATÓRIO
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
