using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Data.Repository
{
    public class OficioEmitidoRepository : Repository<OficioEmitido>, IOficioEmitidoRepository
    {
        public OficioEmitidoRepository(AviationManagementDbContext context) : base(context) { }

        public async Task<PagedResult<OficioEmitido>> ObterTodos(int pageSize, int pageIndex, string query = null)
        {
            var sql = @$"SELECT * FROM Oficios_Emitidos
                      WHERE (@Numeracao IS NULL OR Numeracao LIKE '%' + @Numeracao + '%')
                      ORDER BY [Numeracao]
                      OFFSET {pageSize * (pageIndex - 1)} ROWS
                      FETCH NEXT {pageSize} ROWS ONLY
                      SELECT COUNT(Id) FROM Oficios_Emitidos
                      WHERE (@Numeracao IS NULL OR Numeracao LIKE '%' + @Numeracao + '%')";

            var multi = await Db.Database
                .GetDbConnection()
                .QueryMultipleAsync(sql, new { Numeracao = query });

            var oficiosEmitidos = multi.Read<OficioEmitido>();
            var total = multi.Read<int>().FirstOrDefault();

            return new PagedResult<OficioEmitido>()
            {
                List = oficiosEmitidos,
                TotalResults = total,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }
    }
}
