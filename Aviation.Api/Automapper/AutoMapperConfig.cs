using AutoMapper;
using AviationManagementApi.Api.ViewModels;
using AviationManagementApi.Business.Models;

namespace AviationManagementApi.Api.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Aeronave, AeronaveViewModel>().ReverseMap();
            CreateMap<AeronaveAbastecimento, AeronaveAbastecimentoViewModel>().ReverseMap();
            CreateMap<AeronaveTarifa, AeronaveTarifaViewModel>().ReverseMap();
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();
            CreateMap<AlunoTurma, AlunoTurmaViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Colaborador, ColaboradorViewModel>().ReverseMap();
            CreateMap<Contas, ContasViewModel>().ReverseMap();
            CreateMap<ContasPagar, ContasPagarViewModel>().ReverseMap();
            CreateMap<ContasReceber, ContasReceberViewModel>().ReverseMap();
            CreateMap<Curso, CursoViewModel>().ReverseMap();
            CreateMap<DiarioBordo, DiarioBordoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<ItemOrdemServico, ItemOrdemServicoViewModel>().ReverseMap();
            CreateMap<Legislacao, LegislacaoViewModel>().ReverseMap();
            CreateMap<ManualEmpresa, ManualEmpresaViewModel>().ReverseMap();
            CreateMap<ManualVoo, ManualVooViewModel>().ReverseMap();
            CreateMap<OficioRecebido, OficioRecebidoViewModel>().ReverseMap();
            CreateMap<OficioEmitido, OficioEmitidoViewModel>().ReverseMap();
            CreateMap<OrdemServico, OrdemServicoViewModel>().ReverseMap();
            CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Servico, ServicoViewModel>().ReverseMap();
            CreateMap<Suprimento, SuprimentoViewModel>().ReverseMap();
            CreateMap<SuprimentoMovimentacao, SuprimentoMovimentacaoViewModel>().ReverseMap();
            CreateMap<Turma, TurmaViewModel>().ReverseMap();
            CreateMap<Veiculo, VeiculoViewModel>().ReverseMap();
            CreateMap<VeiculoGasto, VeiculoGastoViewModel>().ReverseMap();
            CreateMap<VeiculoMulta, VeiculoMultaViewModel>().ReverseMap();
            CreateMap<VooAgendado, VooAgendadoViewModel>().ReverseMap();
            CreateMap<VooInstrucao, VooInstrucaoViewModel>().ReverseMap();
            
            CreateMap<AeronaveTarifa, AeronaveTarifaViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));

            CreateMap<AeronaveAbastecimento, AeronaveAbastecimentoViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));

            CreateMap<AlunoTurma, AlunoTurmaViewModel>()
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Nome));

            CreateMap<AlunoTurma, AlunoTurmaViewModel>()
                .ForMember(dest => dest.CodigoTurma, opt => opt.MapFrom(src => src.Turma.Codigo));

            CreateMap<DiarioBordo, DiarioBordoViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));

            CreateMap<DiarioBordo, DiarioBordoViewModel>()
                .ForMember(dest => dest.NomeComandante, opt => opt.MapFrom(src => src.Comandante.Nome));

            //CreateMap<DiarioBordo, DiarioBordoViewModel>()
            //    .ForMember(dest => dest.NomeCopiloto, opt => opt.MapFrom(src => src.Copiloto.Nome));

            //CreateMap<DiarioBordo, DiarioBordoViewModel>()
            //    .ForMember(dest => dest.NomeMecanico, opt => opt.MapFrom(src => src.MecanicoResponsavel.Nome));

            CreateMap<Endereco, EnderecoViewModel>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));

            CreateMap<ItemOrdemServico, ItemOrdemServicoViewModel>()
                .ForMember(dest => dest.NumeroOrdem, opt => opt.MapFrom(src => src.OrdemServico.NumeroOrdem));

            CreateMap<ItemOrdemServico, ItemOrdemServicoViewModel>()
                .ForMember(dest => dest.CodigoServico, opt => opt.MapFrom(src => src.Servico.Codigo));

            CreateMap<OrdemServico, OrdemServicoViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));

            CreateMap<SuprimentoMovimentacao, SuprimentoMovimentacaoViewModel>()
                .ForMember(dest => dest.CodigoItem, opt => opt.MapFrom(src => src.Item.Codigo));

            CreateMap<Turma, TurmaViewModel>()
                .ForMember(dest => dest.CodigoCurso, opt => opt.MapFrom(src => src.Curso.Codigo));

            CreateMap<Turma, TurmaViewModel>()
                .ForMember(dest => dest.DescricaoCurso, opt => opt.MapFrom(src => src.Curso.Descricao));

            CreateMap<VeiculoGasto, VeiculoGastoViewModel>()
                .ForMember(dest => dest.PlacaVeiculo, opt => opt.MapFrom(src => src.Veiculo.Placa));

            CreateMap<VeiculoGasto, VeiculoGastoViewModel>()
                .ForMember(dest => dest.NomeMotorista, opt => opt.MapFrom(src => src.Motorista.Nome));

            CreateMap<VeiculoMulta, VeiculoMultaViewModel>()
                .ForMember(dest => dest.PlacaVeiculo, opt => opt.MapFrom(src => src.Veiculo.Placa));

            CreateMap<VooAgendado, VooAgendadoViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));

            CreateMap<VooInstrucao, VooInstrucaoViewModel>()
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Nome));

            CreateMap<VooInstrucao, VooInstrucaoViewModel>()
                .ForMember(dest => dest.NomeInstrutor, opt => opt.MapFrom(src => src.Instrutor.Nome));

            CreateMap<VooInstrucao, VooInstrucaoViewModel>()
                .ForMember(dest => dest.MatriculaAeronave, opt => opt.MapFrom(src => src.Aeronave.Matricula));
        }
    }
}
