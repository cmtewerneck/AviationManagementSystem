using System.Collections.Generic;
using System.Threading.Tasks;
using AviationManagementApi.Business.Models;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IColaboradorRepository : IPessoaRepository<Colaborador>
    {
        Task<IEnumerable<Colaborador>> ObterColaboradoresPorTipo(TipoColaboradorEnum tipoColaborador);
        
        Task<int> ObterQuantidadeColaboradoresCadastrados(TipoColaboradorEnum tipoColaborador);
    }
}
