using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class OficioEmitidoServices : BaseService, IOficioEmitidoServices
    {
        private readonly IOficioEmitidoRepository _oficioEmitidoRepository;

        public OficioEmitidoServices(IOficioEmitidoRepository oficioEmitidoRepository,
                              INotificador notificador) : base(notificador)
        {
            _oficioEmitidoRepository = oficioEmitidoRepository;
        }

        public async Task<bool> Adicionar(OficioEmitido oficioEmitido)
        {
            if (!ExecutarValidacao(new OficioEmitidoValidation(), oficioEmitido)) return false;

            if (_oficioEmitidoRepository.Buscar(f => f.Numeracao == oficioEmitido.Numeracao).Result.Any())
            {
                Notificar("Já existe um ofício com esta numeração.");
                return false;
            }

            await _oficioEmitidoRepository.Adicionar(oficioEmitido);
            return true;
        }

        public async Task<bool> Atualizar(OficioEmitido oficioEmitido)
        {
            if (!ExecutarValidacao(new OficioEmitidoValidation(), oficioEmitido)) return false;

            if (_oficioEmitidoRepository.Buscar(f => f.Numeracao == oficioEmitido.Numeracao && f.Id != oficioEmitido.Id).Result.Any())
            {
                Notificar("Já existe um ofício com esta numeração.");
                return false;
            }

            await _oficioEmitidoRepository.Atualizar(oficioEmitido);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _oficioEmitidoRepository.Remover(id);
            return true;
        }
        
        public void Dispose()
        {
            _oficioEmitidoRepository?.Dispose();
        }
    }
}
