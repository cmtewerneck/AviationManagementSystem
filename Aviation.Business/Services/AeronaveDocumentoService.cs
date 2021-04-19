using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class AeronaveDocumentoService : BaseService, IAeronaveDocumentoService
    {
        private readonly IAeronaveDocumentoRepository _aeronaveDocumentoRepository;

        public AeronaveDocumentoService(IAeronaveDocumentoRepository aeronaveDocumentoRepository,
                              INotificador notificador) : base(notificador)
        {
            _aeronaveDocumentoRepository = aeronaveDocumentoRepository;
        }

        public async Task<bool> Adicionar(AeronaveDocumento aeronaveDocumento)
        {
            if (!ExecutarValidacao(new AeronaveDocumentoValidation(), aeronaveDocumento)) return false;

            if (_aeronaveDocumentoRepository.Buscar(f => f.Titulo == aeronaveDocumento.Titulo && f.AeronaveId == aeronaveDocumento.AeronaveId).Result.Any())
            {
                Notificar("Já existe este documento para esta aeronave.");
                return false;
            }

            await _aeronaveDocumentoRepository.Adicionar(aeronaveDocumento);
            return true;
        }

        public async Task<bool> Atualizar(AeronaveDocumento aeronaveDocumento)
        {
            if (!ExecutarValidacao(new AeronaveDocumentoValidation(), aeronaveDocumento)) return false;

            if (_aeronaveDocumentoRepository.Buscar(f => f.Titulo == aeronaveDocumento.Titulo && f.AeronaveId == aeronaveDocumento.AeronaveId && f.Id != aeronaveDocumento.Id).Result.Any())
            {
                Notificar("Já existe este documento para esta aeronave.");
                return false;
            }

            await _aeronaveDocumentoRepository.Atualizar(aeronaveDocumento);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _aeronaveDocumentoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _aeronaveDocumentoRepository?.Dispose();
        }
    }
}
