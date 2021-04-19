using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class CategoriaVooService : BaseService, ICategoriaVooService
    {
        private readonly ICategoriaVooRepository _categoriaVooRepository;

        public CategoriaVooService(ICategoriaVooRepository categoriaVooRepository,
                                 INotificador notificador) : base(notificador)
        {
            _categoriaVooRepository = categoriaVooRepository;
        }

        public async Task<bool> Adicionar(CategoriaVoo categoriaVoo)
        {
            if (!ExecutarValidacao(new CategoriaVooValidation(), categoriaVoo)) return false;

            if (_categoriaVooRepository.Buscar(f => f.Codigo == categoriaVoo.Codigo).Result.Any())
            {
                Notificar("Já existe uma categoria com este código.");
                return false;
            }

            await _categoriaVooRepository.Adicionar(categoriaVoo);
            return true;
        }

        public async Task<bool> Atualizar(CategoriaVoo categoriaVoo)
        {
            if (!ExecutarValidacao(new CategoriaVooValidation(), categoriaVoo)) return false;

            if (_categoriaVooRepository.Buscar(f => f.Codigo == categoriaVoo.Codigo && f.Id != categoriaVoo.Id).Result.Any())
            {
                Notificar("Já existe uma categoria com este código.");
                return false;
            }

            await _categoriaVooRepository.Atualizar(categoriaVoo);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_categoriaVooRepository.ObterCategoriaVoo(id).Result.VoosAgendados.Any())
            {
                Notificar("A categoria está cadastrada em Voos. Exclua os Voos ou mude o status da categoria para INATIVA!");
                return false;
            }

            await _categoriaVooRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _categoriaVooRepository?.Dispose();
        }
    }
}
