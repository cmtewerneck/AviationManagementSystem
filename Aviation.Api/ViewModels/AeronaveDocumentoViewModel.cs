using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class AeronaveDocumentoViewModel
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; } // OBRIGATÓRIO (1,50)
        public DateTime? DataEmissao { get; set; } // OPCIONAL
        public DateTime DataValidade { get; set; } // OBRIGATÓRIO

        public string Arquivo { get; set; } // OPCIONAL
        public string ArquivoUpload { get; set; } // OPCIONAL

        public Guid AeronaveId { get; set; }

        [ScaffoldColumn(false)]
        public string MatriculaAeronave { get; set; }
    }
} 
