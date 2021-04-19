using AviationManagementApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IAeronaveMotorService : IDisposable
    {
        Task<bool> Adicionar(AeronaveMotor aeronaveMotor);
        Task<bool> Atualizar(AeronaveMotor aeronaveMotor);
        Task<bool> Remover(Guid id);
    }
}
