using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class TreinamentoService : BaseService, ITreinamentoService
    {
        private readonly ITreinamentoRepository _treinamentoRepository;

        public TreinamentoService(ITreinamentoRepository treinamentoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _treinamentoRepository = treinamentoRepository;
        }

        public async Task<bool> Adicionar(Treinamento treinamento)
        {
            if (!ExecutarValidacao(new TreinamentoValidation(), treinamento)) return false;

            if ((_treinamentoRepository.Buscar(f => f.DataInicio == treinamento.DataInicio).Result.Any()) && (_treinamentoRepository.Buscar(f => f.Tripulante == treinamento.Tripulante).Result.Any()))
            {
                    Notificar("Já existe um treinamento nessa data com esse tripulante.");
                    return false;
            }

            await _treinamentoRepository.Adicionar(treinamento);
            return true;
        }

        public async Task<bool> Atualizar(Treinamento treinamento)
        {
            if (!ExecutarValidacao(new TreinamentoValidation(), treinamento)) return false;

            if ((_treinamentoRepository.Buscar(f => f.DataInicio == treinamento.DataInicio && f.Id != treinamento.Id).Result.Any()) && (_treinamentoRepository.Buscar(f => f.Tripulante == treinamento.Tripulante && f.Id != treinamento.Id).Result.Any()))
            {
                    Notificar("Já existe um treinamento nessa data com esse tripulante.");
                    return false;
            }

            await _treinamentoRepository.Atualizar(treinamento);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _treinamentoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _treinamentoRepository?.Dispose();
        }
    }
}
