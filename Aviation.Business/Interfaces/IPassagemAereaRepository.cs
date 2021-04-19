using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IPassagemAereaRepository : IRepository<PassagemAerea>
    {
        Task<PassagemAerea> ObterPassagemAerea(Guid id);

        Task<PassagemAerea> ObterPassagemAereaColaborador(Guid id);

        Task<IEnumerable<PassagemAerea>> ObterPassagensAereas();

        Task<IEnumerable<PassagemAerea>> ObterPassagensAereasColaborador();
    }
}
