using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementSystem.Business.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AviationManagementSystem.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UserManager<ApplicationUser> _userManager;


        public UsuarioService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<UsuarioListDTO>> ObterListaUsuariosAsync()
        {
            var query = _userManager.Users
               .OrderBy(x => x.Nome)
               .Select(x => new UsuarioListDTO
               {
                   Id = x.Id,
                   Nome = x.Nome + " " + x.Sobrenome
               });
            return await query.ToListAsync();
        }
    }
}
