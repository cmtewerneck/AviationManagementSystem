using System.Collections.Generic;

namespace AviationManagementApi.Business.Models
{
    public class Curso : Entity
    {
        public string Codigo { get; set; } // OBRIGATÓRIO (1,30)
        public string Descricao { get; set; } // OBRIGATÓRIO (1,50)

        public IEnumerable<Turma> Turmas { get; set; }
    }
}