using System;

namespace AviationManagementApi.Business.Models
{
    public class Endereco : Entity
    {
        public string Logradouro { get; set; } // OBRIGATÓRIO (1,50)
        public string Numero { get; set; } // OBRIGATÓRIO (1,20)
        public string Complemento { get; set; } // OPCIONAL (1,20)
        public string Cep { get; set; } // OBRIGATÓRIO (8)
        public string Bairro { get; set; } // OBRIGATÓRIO (1,50)
        public string Cidade { get; set; } // OBRIGATÓRIO (1,50)
        public string Estado { get; set; } // OBRIGATÓRIO (2)

        public Fornecedor Fornecedor { get; set; } // OBRIGATÓRIO
        public Guid FornecedorId { get; set; } 
    }
}