using System;
using System.Linq;
using System.Threading.Tasks;
using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;

namespace AviationManagementApi.Business.Services
{
    public abstract class PessoaService<TEntity, TValidator> : BaseService, IPessoaServices<TEntity>
        where TEntity : Pessoa
        where TValidator : PessoaValidation<TEntity>, new()
    {
        private readonly IPessoaRepository<TEntity> _pessoaRepository;

        public PessoaService(IPessoaRepository<TEntity> pessoaRepository,
                             INotificador notificador) : base(notificador)
        {
            _pessoaRepository = pessoaRepository;
        }

        public virtual async Task<bool> Adicionar(TEntity entity)
        {
            if (!ExecutarValidacao(new TValidator(), entity)) return false;

            if (_pessoaRepository.Buscar(f => f.Documento == entity.Documento).Result.Any())
            {
                Notificar("Já existe uma pessoa com esta numeração.");
                return false;
            }

            await _pessoaRepository.Adicionar(entity);
            return true;
        }

        public virtual async Task<bool> Atualizar(TEntity entity)
        {
            if (!ExecutarValidacao(new TValidator(), entity)) return false;

            if (_pessoaRepository.Buscar(f => f.Documento == entity.Documento && f.Id != entity.Id).Result.Any())
            {
                Notificar("Já existe uma pessoa com esta numeração.");
                return false;
            }

            await _pessoaRepository.Atualizar(entity);
            return true;
        }

        public virtual async Task<bool> Remover(Guid id)
        {
            await _pessoaRepository.Remover(id);
            return true;
        }

        public virtual void Dispose()
        {
            _pessoaRepository?.Dispose();
        }
    }
}
