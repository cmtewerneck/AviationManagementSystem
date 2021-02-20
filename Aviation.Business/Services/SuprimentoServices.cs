using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class SuprimentoServices : BaseService, ISuprimentoServices
    {
        private readonly ISuprimentoRepository _suprimentoRepository;

        public SuprimentoServices(ISuprimentoRepository suprimentoRepository,
                              INotificador notificador) : base(notificador)
        {
            _suprimentoRepository = suprimentoRepository;
        }

        public async Task<bool> Adicionar(Suprimento suprimento)
        {
            if (!ExecutarValidacao(new SuprimentoValidation(), suprimento)) return false;

            if (_suprimentoRepository.Buscar(f => f.PartNumber == suprimento.PartNumber).Result.Any())
            {
                Notificar("Já existe um item com este Part Number.");
                return false;
            }

            await _suprimentoRepository.Adicionar(suprimento);
            return true;
        }

        public async Task<bool> Atualizar(Suprimento suprimento)
        {
            if (!ExecutarValidacao(new SuprimentoValidation(), suprimento)) return false;

            if (_suprimentoRepository.Buscar(f => f.PartNumber == suprimento.PartNumber && f.Id != suprimento.Id).Result.Any())
            {
                Notificar("Já existe um item com este Part Number.");
                return false;
            }

            await _suprimentoRepository.Atualizar(suprimento);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _suprimentoRepository.Remover(id);
            return true;
        }
        
        public void Dispose()
        {
            _suprimentoRepository?.Dispose();
        }
    }
}
