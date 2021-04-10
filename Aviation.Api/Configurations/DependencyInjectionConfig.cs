using AviationManagementApi.Api.Configuration;
using AviationManagementApi.Api.Extensions;
using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Notificacoes;
using AviationManagementApi.Business.Services;
using AviationManagementApi.Data.Context;
using AviationManagementApi.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AviationManagementApi.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AviationManagementDbContext>();
            services.AddScoped<IAeronaveRepository, AeronaveRepository>();
            services.AddScoped<IAeronaveTarifaRepository, AeronaveTarifaRepository>();
            services.AddScoped<IAeronaveAbastecimentoRepository, AeronaveAbastecimentoRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoTurmaRepository, AlunoTurmaRepository>();
            services.AddScoped<ICategoriaTreinamentoRepository, CategoriaTreinamentoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IContasPagarRepository, ContasPagarRepository>();
            services.AddScoped<IContasReceberRepository, ContasReceberRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IDiarioBordoRepository, DiarioBordoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEscalaRepository, EscalaRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IItemOrdemServicoRepository, ItemOrdemServicoRepository>();
            services.AddScoped<ILegislacaoRepository, LegislacaoRepository>();
            services.AddScoped<ILicencaHabilitacaoRepository, LicencaHabilitacaoRepository>();
            services.AddScoped<IManualEmpresaRepository, ManualEmpresaRepository>();
            services.AddScoped<IManualVooRepository, ManualVooRepository>();
            services.AddScoped<IOficioEmitidoRepository, OficioEmitidoRepository>();
            services.AddScoped<IOficioRecebidoRepository, OficioRecebidoRepository>();
            services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();
            //services.AddScoped<IPessoaRepository, PessoaRepository>(); // ERRO
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IRastreadorRepository, RastreadorRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<ISuprimentoRepository, SuprimentoRepository>();
            services.AddScoped<ISuprimentoMovimentacaoRepository, SuprimentoMovimentacaoRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<ITreinamentoRepository, TreinamentoRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoGastoRepository, VeiculoGastoRepository>();
            services.AddScoped<IVeiculoMultaRepository, VeiculoMultaRepository>();
            services.AddScoped<IVooAgendadoRepository, VooAgendadoRepository>();
            services.AddScoped<IVooInstrucaoRepository, VooInstrucaoRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IAeronaveServices, AeronaveServices>();
            services.AddScoped<IAeronaveTarifaServices, AeronaveTarifaService>();
            services.AddScoped<IAeronaveAbastecimentoServices, AeronaveAbastecimentoService>();
            services.AddScoped<IAlunoServices, AlunoService>();
            services.AddScoped<IAlunoTurmaServices, AlunoTurmaService>();
            services.AddScoped<ICategoriaTreinamentoService, CategoriaTreinamentoService>();
            services.AddScoped<IClienteServices, ClienteService>();
            services.AddScoped<IColaboradorServices, ColaboradorService>();
            services.AddScoped<IContasPagarServices, ContasPagarService>();
            services.AddScoped<IContasReceberServices, ContasReceberService>();
            services.AddScoped<ICursoServices, CursoService>();
            services.AddScoped<IDiarioBordoServices, DiarioBordoService>();
            services.AddScoped<IEscalaService, EscalaService>();
            services.AddScoped<IFornecedorServices, FornecedorService>();
            services.AddScoped<IItemOrdemServicoServices, ItemOrdemServicoService>();
            services.AddScoped<ILegislacaoServices, LegislacaoService>();
            services.AddScoped<ILicencaHabilitacaoServices, LicencaHabilitacaoService>();
            services.AddScoped<IManualEmpresaServices, ManualEmpresaService>();
            services.AddScoped<IManualVooServices, ManualVooService>();
            services.AddScoped<IOficioEmitidoServices, OficioEmitidoServices>();
            services.AddScoped<IOficioRecebidoServices, OficioRecebidoServices>();
            services.AddScoped<IOrdemServicoServices, OrdemServicoServices>();
            //services.AddScoped<IPessoaServices, PessoaService>(); // ERRO
            services.AddScoped<IProdutoServices, ProdutoService>();
            services.AddScoped<IRastreadorService, RastreadorService>();
            services.AddScoped<IServicoServices, ServicoServices>();
            services.AddScoped<ISuprimentoServices, SuprimentoServices>();
            services.AddScoped<ISuprimentoMovimentacaoServices, SuprimentoMovimentacaoService>();
            services.AddScoped<ITurmaServices, TurmaServices>();
            services.AddScoped<ITreinamentoService, TreinamentoService>();
            services.AddScoped<IVeiculoServices, VeiculoService>();
            services.AddScoped<IVeiculoGastoServices, VeiculoGastosService>();
            services.AddScoped<IVeiculoMultaServices, VeiculoMultaService>();
            services.AddScoped<IVooAgendadoServices, VooAgendadoService>();
            services.AddScoped<IVooInstrucaoServices, VooInstrucaoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
