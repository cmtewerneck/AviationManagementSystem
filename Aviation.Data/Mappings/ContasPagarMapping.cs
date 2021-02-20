using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class ContasPagarMapping : IEntityTypeConfiguration<ContasPagar>
    {
        public void Configure(EntityTypeBuilder<ContasPagar> builder)
        {
            builder.ToTable("Contas_Pagar");
        }
    }
}
