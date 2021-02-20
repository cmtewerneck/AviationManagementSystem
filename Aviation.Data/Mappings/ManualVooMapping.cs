using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class ManualVooMapping : IEntityTypeConfiguration<ManualVoo>
    {
        public void Configure(EntityTypeBuilder<ManualVoo> builder)
        {
            builder.Property(p => p.ModeloAeronave)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.ToTable("Manuais_Voo");
        }
    }
}
