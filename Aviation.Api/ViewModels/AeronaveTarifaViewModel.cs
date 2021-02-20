using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class AeronaveTarifaViewModel
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; }
        public bool Situacao { get; set; }
        public string Numeracao { get; set; }
        public int OrgaoEmissorTarifa { get; set; }

        public Guid AeronaveId { get; set; }

        [ScaffoldColumn(false)]
        public string MatriculaAeronave { get; set; }
    }
} 
