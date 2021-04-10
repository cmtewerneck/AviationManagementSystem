using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class RastreadorMapping : IEntityTypeConfiguration<Rastreador>
    {
        public void Configure(EntityTypeBuilder<Rastreador> builder)
        {
            builder.Property(c => c.Codigo)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.HasIndex(c => c.Codigo).IsUnique();

            builder.Property(c => c.Modelo)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.ToTable("Rastreadores");
        }
    }
}
