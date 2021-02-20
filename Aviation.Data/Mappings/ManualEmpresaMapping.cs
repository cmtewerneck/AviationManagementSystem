using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class ManualEmpresaMapping : IEntityTypeConfiguration<ManualEmpresa>
    {
        public void Configure(EntityTypeBuilder<ManualEmpresa> builder)
        {
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Sigla)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            builder.ToTable("Manuais_Empresa");
        }
    }
}
