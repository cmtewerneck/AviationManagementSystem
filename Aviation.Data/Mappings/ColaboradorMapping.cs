using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class ColaboradorMapping : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.Property(c => c.Cargo)
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.CANAC)
                .HasMaxLength(6)
                .HasColumnType("varchar(6)");

            builder.Property(p => p.RG)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.OrgaoEmissor)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.TituloEleitor)
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.NumeroPis)
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.NumeroCtps)
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.NumeroCnh)
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.ToTable("Colaboradores");
        }
    }
}
