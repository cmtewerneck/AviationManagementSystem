using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class ContasReceberMapping : IEntityTypeConfiguration<ContasReceber>
    {
        public void Configure(EntityTypeBuilder<ContasReceber> builder)
        {
            builder.ToTable("Contas_Receber");
        }
    }
}
