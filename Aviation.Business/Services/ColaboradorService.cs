using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using AviationManagementApi.Business.Models.Validations;

namespace AviationManagementApi.Business.Services
{
    public class ColaboradorService : PessoaService<Colaborador, ColaboradorValidation>, IColaboradorServices
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository, 
                                  INotificador notificador) : base(colaboradorRepository, notificador)
        {
            _colaboradorRepository = colaboradorRepository;
        }
    }
}
