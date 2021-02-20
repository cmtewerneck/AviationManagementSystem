using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class OficioRecebidoServices : BaseService, IOficioRecebidoServices
    {
        private readonly IOficioRecebidoRepository _oficioRecebidoRepository;

        public OficioRecebidoServices(IOficioRecebidoRepository oficioRecebidoRepository,
                              INotificador notificador) : base(notificador)
        {
            _oficioRecebidoRepository = oficioRecebidoRepository;
        }

        public async Task<bool> Adicionar(OficioRecebido oficioRecebido)
        {
            if (!ExecutarValidacao(new OficioRecebidoValidation(), oficioRecebido)) return false;

            if (_oficioRecebidoRepository.Buscar(f => f.Numeracao == oficioRecebido.Numeracao).Result.Any())
            {
                Notificar("Já existe um ofício com esta numeração.");
                return false;
            }

            await _oficioRecebidoRepository.Adicionar(oficioRecebido);
            return true;
        }

        public async Task<bool> Atualizar(OficioRecebido oficioRecebido)
        {
            if (!ExecutarValidacao(new OficioRecebidoValidation(), oficioRecebido)) return false;

            if (_oficioRecebidoRepository.Buscar(f => f.Numeracao == oficioRecebido.Numeracao && f.Id != oficioRecebido.Id).Result.Any())
            {
                Notificar("Já existe um ofício com esta numeração.");
                return false;
            }

            await _oficioRecebidoRepository.Atualizar(oficioRecebido);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _oficioRecebidoRepository.Remover(id);
            return true;
        }
        
        public void Dispose()
        {
            _oficioRecebidoRepository?.Dispose();
        }
    }
}
