using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class ContasMapping : IEntityTypeConfiguration<Contas>
    {
        public void Configure(EntityTypeBuilder<Contas> builder)
        {
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.CodigoBarras)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.FormaPagamento)
               .HasMaxLength(30)
               .HasColumnType("varchar(30)");

            builder.ToTable("Contas");
        }
    }
}
