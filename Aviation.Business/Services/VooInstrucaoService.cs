using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Services
{
    public class VooInstrucaoService : BaseService, IVooInstrucaoServices
    {
        private readonly IVooInstrucaoRepository _vooInstrucaoRepository;

        public VooInstrucaoService(IVooInstrucaoRepository vooInstrucaoRepository,
                              INotificador notificador) : base(notificador)
        {
            _vooInstrucaoRepository = vooInstrucaoRepository;
        }

        public async Task<bool> Adicionar(VooInstrucao vooInstrucao)
        {
            if (!ExecutarValidacao(new VooInstrucaoValidation(), vooInstrucao)) return false;

            // Colocar validação para o caso de um voo com a mesma aeronave na mesma data e hora

            await _vooInstrucaoRepository.Adicionar(vooInstrucao);
            return true;
        }

        public async Task<bool> Atualizar(VooInstrucao vooInstrucao)
        {
            if (!ExecutarValidacao(new VooInstrucaoValidation(), vooInstrucao)) return false;

            await _vooInstrucaoRepository.Atualizar(vooInstrucao);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _vooInstrucaoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _vooInstrucaoRepository?.Dispose();
        }
    }
}
