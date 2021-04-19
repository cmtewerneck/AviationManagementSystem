using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ICategoriaVooService : IDisposable
    {
        Task<bool> Adicionar(CategoriaVoo categoriaVoo);
        Task<bool> Atualizar(CategoriaVoo categoriaVoo);
        Task<bool> Remover(Guid id);
    }
}
