using AviationManagementApi.Api.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Moeda]
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        
        public string Imagem { get; set; } 
        public string ImagemUpload { get; set; }

        public Guid FornecedorId { get; set; }

        [ScaffoldColumn(false)]
        public string NomeFornecedor { get; set; }
    }
} 
