using System.ComponentModel;

namespace AviationManagementApi.Business.Models
{
    public enum StatusEscalaEnum
    {
        [Description("SERVIÇO")]
        SE = 1,
        [Description("FÉRIAS")]
        FE = 2,
        [Description("FOLGA REGULAR")]
        FR = 3,
        [Description("FOLGA SOCIAL")]
        FS = 4,
        [Description("CHECK")]
        CQ = 5,
        [Description("LICENÇA MÉDICA")]
        LM = 6,
        [Description("DISPENSA DE SERVIÇO")]
        DS = 7,
        [Description("TREINAMENTO")]
        TN = 8,
        [Description("RESERVA")]
        RE = 9,
        [Description("ADMINISTRATIVO")]
        AD = 10
    }
}
