using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            // RELATIONSHIP
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor);

            builder.ToTable("Fornecedores");
        }
    }
}
