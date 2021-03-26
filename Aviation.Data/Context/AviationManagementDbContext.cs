using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AviationManagementApi.Data.Context
{
    public class AviationManagementDbContext : DbContext
    {
        public AviationManagementDbContext(DbContextOptions<AviationManagementDbContext> options) : base(options) { }

        public DbSet<Aeronave> Aeronaves { get; set; }
        public DbSet<AeronaveAbastecimento> AeronavesAbastecimentos { get; set; }
        public DbSet<AeronaveTarifa> AeronavesTarifas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoTurma> AlunosTurmas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Contas> Contas { get; set; }
        public DbSet<ContasPagar> ContasPagar { get; set; }
        public DbSet<ContasReceber> ContasReceber { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<DiarioBordo> DiariosBordo { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<ItemOrdemServico> ItensOrdensServico { get; set; }
        public DbSet<Legislacao> Legislacoes { get; set; }
        public DbSet<ManualEmpresa> ManuaisEmpresa { get; set; }
        public DbSet<ManualVoo> ManuaisVoo { get; set; }
        public DbSet<OficioEmitido> OficiosEmitidos { get; set; }
        public DbSet<OficioRecebido> OficiosRecebidos { get; set; }
        public DbSet<OrdemServico> OrdensServico { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Suprimento> Suprimentos { get; set; }
        public DbSet<SuprimentoMovimentacao> SuprimentosMovimentacoes { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<VeiculoGasto> VeiculoGastos { get; set; }
        public DbSet<VeiculoMulta> VeiculoMultas { get; set; }
        public DbSet<VooAgendado> VoosAgendados { get; set; }
        public DbSet<VooInstrucao> VoosInstrucoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AviationManagementDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
