using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class RastreadorViewModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Modelo { get; set; }

        public Guid AeronaveId { get; set; }

        [ScaffoldColumn(false)]
        public string MatriculaAeronave { get; set; }
    }
}
