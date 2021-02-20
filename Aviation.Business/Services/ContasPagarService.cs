using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;

namespace AviationManagementApi.Business.Services
{
    public class ContasPagarService : ContasService<ContasPagar, ContasPagarValidation>, IContasPagarServices
    {
        private readonly IContasPagarRepository _contasPagarRepository;

        public ContasPagarService(IContasPagarRepository contasPagarRepository,
                                 INotificador notificador) : base(contasPagarRepository, notificador)
        {
            _contasPagarRepository = contasPagarRepository;
        }
    }
}
