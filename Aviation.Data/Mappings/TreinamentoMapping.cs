using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class TreinamentoMapping : IEntityTypeConfiguration<Treinamento>
    {
        public void Configure(EntityTypeBuilder<Treinamento> builder)
        {
            builder.Property(p => p.ModeloAeronave)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Instrutor)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            // RELATIONSHIP
            builder.HasOne(x => x.Tripulante)
                .WithMany(x => x.Treinamentos)
                .HasForeignKey(x => x.TripulanteId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Treinamentos)
                .HasForeignKey(x => x.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Treinamentos");
        }
    }
}
