using Microsoft.AspNetCore.Identity;

namespace AviationManagementApi.Business.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; } // OBRIGATÓRIO (30)
        public string Sobrenome { get; set; } // OBRIGATÓRIO (100)
        public string Telefone { get; set; } // OPCIONAL (20)
        public string Empresa { get; set; } // OBRIGATÓRIO (100)
        public string EmpresaCnpj { get; set; } // OBRIGATÓRIO (14)
    }
}
