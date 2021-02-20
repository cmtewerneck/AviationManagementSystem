using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class LegislacaoMapping : IEntityTypeConfiguration<Legislacao>
    {
        public void Configure(EntityTypeBuilder<Legislacao> builder)
        {
            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.ToTable("Legislacoes");
        }
    }
}
