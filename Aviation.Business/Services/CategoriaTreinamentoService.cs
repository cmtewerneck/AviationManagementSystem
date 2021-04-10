using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class CategoriaTreinamentoService : BaseService, ICategoriaTreinamentoService
    {
        private readonly ICategoriaTreinamentoRepository _categoriaTreinamentoRepository;

        public CategoriaTreinamentoService(ICategoriaTreinamentoRepository categoriaTreinamentoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _categoriaTreinamentoRepository = categoriaTreinamentoRepository;
        }

        public async Task<bool> Adicionar(CategoriaTreinamento categoriaTreinamento)
        {
            if (!ExecutarValidacao(new CategoriaTreinamentoValidation(), categoriaTreinamento)) return false;

            if (_categoriaTreinamentoRepository.Buscar(f => f.Codigo == categoriaTreinamento.Codigo).Result.Any())
            {
                Notificar("Já existe uma categoria com este código.");
                return false;
            }

            await _categoriaTreinamentoRepository.Adicionar(categoriaTreinamento);
            return true;
        }

        public async Task<bool> Atualizar(CategoriaTreinamento categoriaTreinamento)
        {
            if (!ExecutarValidacao(new CategoriaTreinamentoValidation(), categoriaTreinamento)) return false;

            if (_categoriaTreinamentoRepository.Buscar(f => f.Codigo == categoriaTreinamento.Codigo && f.Id != categoriaTreinamento.Id).Result.Any())
            {
                Notificar("Já existe uma categoria com este código.");
                return false;
            }

            await _categoriaTreinamentoRepository.Atualizar(categoriaTreinamento);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_categoriaTreinamentoRepository.ObterCategoriaTreinamento(id).Result.Treinamentos.Any())
            {
                Notificar("A categoria está cadastrada em treinamentos. Exclua os treinamentos ou mude o status da categoria para INATIVA!");
                return false;
            }

            await _categoriaTreinamentoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _categoriaTreinamentoRepository?.Dispose();
        }
    }
}
