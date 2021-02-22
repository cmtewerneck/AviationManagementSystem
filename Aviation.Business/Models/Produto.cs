using System;

namespace AviationManagementApi.Business.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; } // OBRIGATÓRIO (1,100)
        public string Descricao { get; set; } // OBRIGATÓRIO (1,500)
        public decimal Valor { get; set; } // OBRIGATÓRIO > 0
        public bool Ativo { get; set; } // OBRIGATÓRIO
        
        public string Imagem { get; set; } // OBRIGATÓRIO

        public Fornecedor Fornecedor { get; set; } 
        public Guid FornecedorId { get; set; } // OBRIGATÓRIO
    }
}
