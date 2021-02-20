using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;

namespace AviationManagementApi.Business.Services
{
    public class ContasReceberService : ContasService<ContasReceber, ContasReceberValidation>, IContasReceberServices
    {
        private readonly IContasReceberRepository _contasReceberRepository;

        public ContasReceberService(IContasReceberRepository contasReceberRepository,
                                 INotificador notificador) : base(contasReceberRepository, notificador)
        {
            _contasReceberRepository = contasReceberRepository;
        }
    }
}
