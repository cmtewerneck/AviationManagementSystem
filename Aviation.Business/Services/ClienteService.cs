using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;

namespace AviationManagementApi.Business.Services
{
    public class ClienteService : PessoaService<Cliente, ClienteValidation>, IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository, INotificador notificador) : base(clienteRepository, notificador)
        {
            _clienteRepository = clienteRepository;
        }
    }
}
