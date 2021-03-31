using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface ILicencaHabilitacaoRepository : IRepository<LicencaHabilitacao>
    {
        Task<IEnumerable<LicencaHabilitacao>> ObterLicencasColaboradores();
        
        Task<LicencaHabilitacao> ObterLicencaColaborador(Guid id);
    }
}
