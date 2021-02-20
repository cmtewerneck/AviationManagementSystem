using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ILegislacaoServices : IDisposable
    {
        Task<bool> Adicionar(Legislacao legislacao);
        Task<bool> Atualizar(Legislacao legislacao);
        Task<bool> Remover(Guid id);
    }
}
