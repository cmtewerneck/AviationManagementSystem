using System.ComponentModel;

namespace AviationManagementApi.Business.Models
{
    public enum ItemOrdemServicoStatusEnum
    {
        [Description("Pendente")]
        Pendente = 1,

        [Description("Em Execução")]
        EmExecucao = 2,

        [Description("Aguardando Peça")]
        AguardandoPeca = 3,

        [Description("Finalizado")]
        Finalizado = 4
    }
}
