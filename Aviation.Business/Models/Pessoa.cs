namespace AviationManagementApi.Business.Models
{
    public class Pessoa : Entity
    {
        public string Nome { get; set; }  // OBRIGATÓRIO (1,100)
        public TipoPessoaEnum TipoPessoa { get; set; } // OBRIGATÓRIO
        public string Documento { get; set; } // OBRIGATÓRIO (11,14)
        public SexoEnum Sexo { get; set; } // OBRIGATÓRIO
        public string EstadoCivil { get; set; } // OPCIONAL (1,20)
        public bool Ativo { get; set; } // OBRIGATÓRIO
        public string Telefone { get; set; } // OPCIONAL (1,20)
        public string Email { get; set; } // OPCIONAL (1,50)

        public string Imagem { get; set; } // OPCIONAL
    }
}
