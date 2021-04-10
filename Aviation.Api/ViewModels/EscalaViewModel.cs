using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class EscalaViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public int Status { get; set; }

        public Guid TripulanteId { get; set; }

        [ScaffoldColumn(false)]
        public string NomeTripulante { get; set; }
    }
} 
