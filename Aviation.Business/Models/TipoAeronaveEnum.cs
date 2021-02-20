using System.ComponentModel;

namespace AviationManagementApi.Business.Models
{
    public enum TipoAeronaveEnum
    {
        [Description("Monomotor Convencional")]
        MonomotorConvencional = 1,
        [Description("Monomotor a Turbina")]
        Monoturbina = 2,
        [Description("Multimotor a Turbina")]
        Multiturbina = 3
    }
}