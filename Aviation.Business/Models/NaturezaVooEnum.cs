using System.ComponentModel;

namespace AviationManagementApi.Business.Models
{
    public enum NaturezaVooEnum
    {
        [Description("AUTORIZAÇÃO ESPECIAL")]
        AE = 1,
        [Description("CHECK")]
        CQ = 2,
        [Description("EXPERIÊNCIA")]
        EX = 3,
        [Description("VOO NÃO REGULAR")]
        NR = 4,
        [Description("VOO REGULAR")]
        RE = 5,
        [Description("PRIVADO")]
        PV = 6,
        [Description("SERVIÇO AÉREO ESPECIALIZADO")]
        SA = 7,
        [Description("TREINAMENTO")]
        TN = 8,
        [Description("TRANSLADO")]
        TR = 9,
        [Description("FRETAMENTO")]
        FR = 10
    }
}
