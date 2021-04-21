using System.Linq;
using AutoMapper;
using AviationManagementApi.Api.ViewModels;
using AviationManagementApi.Business.Models;
using AviationManagementSystem.Api.ViewModels;
using AviationManagementSystem.Business.DTOs;

namespace AviationManagementApi.Api.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Aeronave, AeronaveViewModel>().ReverseMap();
            CreateMap<AeronaveAbastecimento, AeronaveAbastecimentoViewModel>().ReverseMap();
            CreateMap<AeronaveMotor, AeronaveMotorViewModel>().ReverseMap();
            CreateMap<AeronaveDocumento, AeronaveDocumentoViewModel>().ReverseMap();
            CreateMap<AeronaveDiretriz, AeronaveDiretrizViewModel>().ReverseMap();
            CreateMap<AeronaveTarifa, AeronaveTarifaViewModel>().ReverseMap();
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();
            CreateMap<AlunoTurma, AlunoTurmaViewModel>().ReverseMap();
            CreateMap<CategoriaVoo, CategoriaVooViewModel>().ReverseMap();
            CreateMap<CategoriaTreinamento, CategoriaTreinamentoViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Colaborador, ColaboradorViewModel>().ReverseMap();
            CreateMap<Contas, ContasViewModel>().ReverseMap();
            CreateMap<ContasPagar, ContasPagarViewModel>().ReverseMap();
            CreateMap<ContasReceber, ContasReceberViewModel>().ReverseMap();
            CreateMap<Curso, CursoViewModel>().ReverseMap();
            CreateMap<DiariaTripulante, DiariaTripulanteViewModel>().ReverseMap();
            CreateMap<DiarioBordo, DiarioBordoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Escala, EscalaViewModel>().ReverseMap();
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<ItemOrdemServico, ItemOrdemServicoViewModel>().ReverseMap();
            CreateMap<Legislacao, LegislacaoViewModel>().ReverseMap();
            CreateMap<LicencaHabilitacao, LicencaHabilitacaoViewModel>().ReverseMap();
            CreateMap<ManualEmpresa, ManualEmpresaViewModel>().ReverseMap();
            CreateMap<ManualVoo, ManualVooViewModel>().ReverseMap();
            CreateMap<OficioRecebido, OficioRecebidoViewModel>().ReverseMap();
            CreateMap<OficioEmitido, OficioEmitidoViewModel>().ReverseMap();
            CreateMap<OrdemServico, OrdemServicoViewModel>().ReverseMap();
            CreateMap<PassagemAerea, PassagemAereaViewModel>().ReverseMap();
            CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Rastreador, RastreadorViewModel>().ReverseMap();
            CreateMap<Servico, ServicoViewModel>().ReverseMap();
            CreateMap<Suprimento, SuprimentoViewModel>().ReverseMap();
            CreateMap<SuprimentoMovimentacao, SuprimentoMovimentacaoViewModel>().ReverseMap();
            CreateMap<Treinamento, TreinamentoViewModel>().ReverseMap();
            CreateMap<Veiculo, VeiculoViewModel>().ReverseMap();
            CreateMap<VeiculoGasto, VeiculoGastoViewModel>().ReverseMap();
            CreateMap<VeiculoMulta, VeiculoMultaViewModel>().ReverseMap();
            CreateMap<VooAgendado, VooAgendadoViewModel>().ReverseMap();
            CreateMap<VooInstrucao, VooInstrucaoViewModel>().ReverseMap();

            // MAPEAMENTO PARA O USUÁRIO
            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();


            CreateMap<AeronaveTarifa, AeronaveTarifaViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));

            CreateMap<AeronaveAbastecimento, AeronaveAbastecimentoViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));

            CreateMap<AeronaveMotor, AeronaveMotorViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));

            CreateMap<AeronaveDocumento, AeronaveDocumentoViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));

            CreateMap<AeronaveDiretriz, AeronaveDiretrizViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula))
                .ForMember(dest => dest.HorasTotaisAeronave, opt => opt.MapFrom(src => src.Aeronave.HorasTotais));

            CreateMap<AlunoTurma, AlunoTurmaViewModel>()
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Nome))
                .ForMember(dest => dest.CodigoTurma, opt => opt.MapFrom(src => src.Turma.Codigo));

            CreateMap<DiarioBordo, DiarioBordoViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula))
                .ForMember(dest => dest.NomeComandante, opt => opt.MapFrom(src => src.Comandante.Nome))
                .ForMember(dest => dest.NomeCopiloto, opt => opt.MapFrom(src => src.Copiloto.Nome))
                .ForMember(dest => dest.NomeMecanico, opt => opt.MapFrom(src => src.MecanicoResponsavel.Nome));

            CreateMap<DiariaTripulante, DiariaTripulanteViewModel>()
                .ForMember(dest => dest.NomeTripulante, opt => opt.MapFrom(src => src.Tripulante.Nome));

            CreateMap<Endereco, EnderecoViewModel>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));

            CreateMap<Escala, EscalaViewModel>()
                .ForMember(dest => dest.NomeTripulante, opt => opt.MapFrom(src => src.Tripulante.Nome));

            CreateMap<ItemOrdemServico, ItemOrdemServicoViewModel>()
                .ForMember(dest => dest.NumeroOrdem, opt => opt.MapFrom(src => src.OrdemServico.NumeroOrdem))
                .ForMember(dest => dest.CodigoServico, opt => opt.MapFrom(src => src.Servico.Codigo));

            CreateMap<OrdemServico, OrdemServicoViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));

            CreateMap<SuprimentoMovimentacao, SuprimentoMovimentacaoViewModel>()
                .ForMember(dest => dest.CodigoItem, opt => opt.MapFrom(src => src.Item.Codigo))
                .ForMember(dest => dest.NomenclaturaItem, opt => opt.MapFrom(src => src.Item.Nomenclatura));

            CreateMap<VeiculoGasto, VeiculoGastoViewModel>()
                .ForMember(dest => dest.PlacaVeiculo, opt => opt.MapFrom(src => src.Veiculo.Placa))
                .ForMember(dest => dest.NomeMotorista, opt => opt.MapFrom(src => src.Motorista.Nome));

            CreateMap<VeiculoMulta, VeiculoMultaViewModel>()
                .ForMember(dest => dest.PlacaVeiculo, opt => opt.MapFrom(src => src.Veiculo.Placa));

            CreateMap<VooAgendado, VooAgendadoViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));

            CreateMap<VooInstrucao, VooInstrucaoViewModel>()
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Nome))
                .ForMember(dest => dest.NomeInstrutor, opt => opt.MapFrom(src => src.Instrutor.Nome))
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));

            CreateMap<Aluno, AlunoViewModel>()
                .ForMember(dest => dest.Turmas, opt => opt.MapFrom(src => src.AlunosTurmas.Select(x => x.Turma).ToList()));

            CreateMap<Turma, TurmaViewModel>().ReverseMap();

            CreateMap<Turma, TurmaViewModel>()
                .ForMember(dest => dest.CodigoCurso, opt => opt.MapFrom(src => src.Curso.Codigo))
                .ForMember(dest => dest.DescricaoCurso, opt => opt.MapFrom(src => src.Curso.Descricao));
            //.ForMember(dest => dest.Alunos, opt => opt.MapFrom(src => src.AlunosTurmas.Select(x => x.Aluno).ToList()));

            CreateMap<LicencaHabilitacao, LicencaHabilitacaoViewModel>()
                .ForMember(dest => dest.NomeColaborador, opt => opt.MapFrom(src => src.Colaborador.Nome));

            CreateMap<Rastreador, RastreadorViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));

            CreateMap<Treinamento, TreinamentoViewModel>()
                .ForMember(dest => dest.NomeTripulante, opt => opt.MapFrom(src => src.Tripulante.Nome))
                .ForMember(dest => dest.DescricaoCategoria, opt => opt.MapFrom(src => src.Categoria.Descricao));

            CreateMap<PassagemAerea, PassagemAereaViewModel>()
               .ForMember(dest => dest.NomeColaborador, opt => opt.MapFrom(src => src.Colaborador.Nome));

            CreateMap<UsuarioListDTO, UsuarioListViewModel>();
        }
    }
}
