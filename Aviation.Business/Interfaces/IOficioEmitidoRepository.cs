using AviationManagementApi.Business.Models;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IOficioEmitidoRepository : IRepository<OficioEmitido>
    {
        Task<PagedResult<OficioEmitido>> ObterTodos(int pageSize, int pageIndex, string query = null);
    }
}