using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class AeronaveDocumentoMapping : IEntityTypeConfiguration<AeronaveDocumento>
    {
        public void Configure(EntityTypeBuilder<AeronaveDocumento> builder)
        {
            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.DataValidade)
                .IsRequired();

            // RELATIONSHIP
            builder.HasOne(x => x.Aeronave)
                .WithMany(x => x.AeronaveDocumentos)
                .HasForeignKey(x => x.AeronaveId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Aeronaves_Documentos");
        }
    }
}
