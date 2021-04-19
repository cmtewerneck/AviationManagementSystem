using System;
using System.ComponentModel.DataAnnotations;

namespace AviationManagementApi.Api.ViewModels
{
    public class VooAgendadoViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } 
        public DateTime Start { get; set; } 
        public DateTime End { get; set; } 
        public bool AllDay { get; set; } 
        public bool Editable { get; set; } 
        public bool DurationEditable { get; set; } 
        public string BackgroundColor { get; set; } 
        public string TextColor { get; set; } 

        public Guid AeronaveId { get; set; }
        public Guid CategoriaId { get; set; }

        [ScaffoldColumn(false)]
        public string MatriculaAeronave { get; set; }

        [ScaffoldColumn(false)]
        public string DescricaoCategoria { get; set; }
    }
} 
