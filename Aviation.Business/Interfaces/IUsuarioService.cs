using System.Collections.Generic;
using System.Threading.Tasks;
using AviationManagementSystem.Business.DTOs;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IUsuarioService 
    {
        Task<IEnumerable<UsuarioListDTO>> ObterListaUsuariosAsync();
    }
}
