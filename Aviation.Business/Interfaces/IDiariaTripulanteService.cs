using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IDiariaTripulanteService : IDisposable
    {
        Task<bool> Adicionar(DiariaTripulante diariaTripulante);
        Task<bool> Atualizar(DiariaTripulante diariaTripulante);
        Task<bool> Remover(Guid id);
    }
}
