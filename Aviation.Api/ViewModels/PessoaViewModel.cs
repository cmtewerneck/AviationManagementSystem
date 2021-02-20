using System;

namespace AviationManagementApi.Api.ViewModels
{
    public class PessoaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int TipoPessoa { get; set; }
        public string Documento { get; set; }
        public int Sexo { get; set; }
        public string EstadoCivil { get; set; } 
        public bool Ativo { get; set; } 
        public string Telefone { get; set; } 
        public string Email { get; set; }

        public string ImagemUpload { get; set; }
        public string Imagem { get; set; }
    }
} 
