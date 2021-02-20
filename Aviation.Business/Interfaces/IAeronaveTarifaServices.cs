using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAeronaveTarifaServices : IDisposable
    {
        Task<bool> Adicionar(AeronaveTarifa aeronaveTarifa);
        Task<bool> Atualizar(AeronaveTarifa aeronaveTarifa);
        Task<bool> Remover(Guid id);
    }
}
