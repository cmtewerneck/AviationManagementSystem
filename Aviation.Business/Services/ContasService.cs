using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class ContasService<TEntity, TValidator> : BaseService, IContasServices<TEntity>
        where TEntity : Contas
        where TValidator : ContasValidation<TEntity>, new()
    {
        private readonly IContasRepository<TEntity> _contasRepository;

        public ContasService(IContasRepository<TEntity> contasRepository,
                                 INotificador notificador) : base(notificador)
        {
            _contasRepository = contasRepository;
        }

        public async Task<bool> Adicionar(TEntity entity)
        {
            if (!ExecutarValidacao(new TValidator(), entity)) return false;

            await _contasRepository.Adicionar(entity);
            return true;
        }

        public async Task<bool> Atualizar(TEntity entity)
        {
            if (!ExecutarValidacao(new TValidator(), entity)) return false;

            await _contasRepository.Atualizar(entity);
            return true;
        }

        public virtual async Task<bool> Remover(Guid id)
        {
            await _contasRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _contasRepository?.Dispose();
        }
    }
}
