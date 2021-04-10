using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class CategoriaTreinamentoMapping : IEntityTypeConfiguration<CategoriaTreinamento>
    {
        public void Configure(EntityTypeBuilder<CategoriaTreinamento> builder)
        {
            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.ToTable("Categorias_Treinamentos");
        }
    }
}
