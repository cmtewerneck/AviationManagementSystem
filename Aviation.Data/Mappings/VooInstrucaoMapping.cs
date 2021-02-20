using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class VooInstrucaoMapping : IEntityTypeConfiguration<VooInstrucao>
    {
        public void Configure(EntityTypeBuilder<VooInstrucao> builder)
        {
            builder.Property(p => p.Observacoes)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            // RELATIONSHIP
            builder.HasOne(x => x.Aluno)
                .WithMany(x => x.VoosInstrucao)
                .HasForeignKey(x => x.AlunoId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Aeronave)
                .WithMany(x => x.VoosInstrucao)
                .HasForeignKey(x => x.AeronaveId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Instrutor)
                .WithMany(x => x.VoosInstrucao)
                .HasForeignKey(x => x.InstrutorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Voos_Instrucao");
        }
    }
}
