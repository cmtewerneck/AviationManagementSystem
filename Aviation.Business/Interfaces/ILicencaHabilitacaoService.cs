using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ILicencaHabilitacaoServices : IDisposable
    {
        Task<bool> Adicionar(LicencaHabilitacao licencaHabilitacao);
        Task<bool> Atualizar(LicencaHabilitacao licencaHabilitacao);
        Task<bool> Remover(Guid id);
    }
}
