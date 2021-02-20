using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ISuprimentoServices : IDisposable
    {
        Task<bool> Adicionar(Suprimento suprimento);
        Task<bool> Atualizar(Suprimento suprimento);
        Task<bool> Remover(Guid id);
    }
}
