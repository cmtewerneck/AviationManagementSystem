using AviationManagementApi.Business.Notificacoes;
using System.Collections.Generic;

namespace AviationManagementApi.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
