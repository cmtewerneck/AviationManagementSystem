using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class LicencaHabilitacaoMapping : IEntityTypeConfiguration<LicencaHabilitacao>
    {
        public void Configure(EntityTypeBuilder<LicencaHabilitacao> builder)
        {
            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            // RELATIONSHIP
            builder.HasOne(x => x.Colaborador)
                .WithMany(x => x.LicencasHabilitacoes)
                .HasForeignKey(x => x.ColaboradorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Licencas_Habilitacoes");
        }
    }
}
