using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class AeronaveAbastecimentoViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public int Litros { get; set; }
        public string Local { get; set; }
        public string Cupom { get; set; }
        public string NotaFiscal { get; set; }
        public string Fornecedora { get; set; }
        public string Responsavel { get; set; }
        public decimal? Valor { get; set; }
        public string Observacoes { get; set; }

        public string Comprovante { get; set; } // OPCIONAL (1,100)
        public string ComprovanteUpload { get; set; } // OPCIONAL (1,100)

        public Guid AeronaveId { get; set; }

        [ScaffoldColumn(false)]
        public string MatriculaAeronave { get; set; }
    }
} 
