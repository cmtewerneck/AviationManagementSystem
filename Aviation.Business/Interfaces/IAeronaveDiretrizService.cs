using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAeronaveDiretrizService : IDisposable
    {
        Task<bool> Atualizar(AeronaveDiretriz aeronaveDiretriz);
        Task<bool> Adicionar(AeronaveDiretriz aeronaveDiretriz);
        Task<bool> Remover(Guid id);
    }
}
