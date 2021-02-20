using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aviation.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeronaves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Matricula = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Categoria = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    NumeroSerie = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Ano = table.Column<int>(type: "int", nullable: true),
                    PesoVazio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PesoBasico = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HorasTotais = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HorasRestantes = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TipoAeronave = table.Column<int>(type: "int", nullable: false),
                    VencimentoCA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VencimentoCVA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VencimentoCM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimaPesagem = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProximaPesagem = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VencimentoReta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VencimentoCasco = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Motor = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    ModeloMotor = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    NumeroSerieMotor = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeronaves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CodigoBarras = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    FormaPagamento = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Legislacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    TipoLegislacao = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Emenda = table.Column<int>(type: "int", nullable: true),
                    DataEmenda = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Arquivo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legislacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manuais_Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Sigla = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    RevisaoAtual = table.Column<int>(type: "int", nullable: false),
                    DataRevisao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevisaoAnalise = table.Column<int>(type: "int", nullable: true),
                    Arquivo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manuais_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manuais_Voo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModeloAeronave = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    UltimaRevisao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Arquivo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manuais_Voo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oficios_Emitidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numeracao = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Mensagem = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    Responsavel = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Destinatario = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Assunto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Arquivo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oficios_Emitidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oficios_Recebidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numeracao = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Assunto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Remetente = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Arquivo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oficios_Recebidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    EstadoCivil = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Titulo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suprimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    PartNumber = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Nomenclatura = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Localizacao = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    PartNumberAlternativo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Aplicacao = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Capitulo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    SerialNumber = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Doc = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suprimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Placa = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    UfPlaca = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: true),
                    Proprio = table.Column<bool>(type: "bit", nullable: false),
                    KmAtual = table.Column<int>(type: "int", nullable: true),
                    Modelo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Renavam = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aeronaves_Abastecimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Litros = table.Column<int>(type: "int", nullable: false),
                    Local = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Cupom = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    NotaFiscal = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Fornecedora = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Responsavel = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Observacoes = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Comprovante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeronaves_Abastecimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aeronaves_Abastecimentos_Aeronaves_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "Aeronaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aeronaves_Tarifas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Situacao = table.Column<bool>(type: "bit", nullable: false),
                    Numeracao = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    OrgaoEmissorTarifa = table.Column<int>(type: "int", nullable: false),
                    AeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeronaves_Tarifas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aeronaves_Tarifas_Aeronaves_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "Aeronaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ordens_Servico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroOrdem = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Tipo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Ttsn = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    TcsnPousos = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    DataAbertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TtsnMotor = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    TcsnCiclos = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    DataFechamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequisicaoMateriais = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    RealizadoPor = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    RealizadoPorAnac = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    DataRealizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InspecionadoPor = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    InspecionadoPorAnac = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    DataInspecao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordens_Servico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordens_Servico_Aeronaves_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "Aeronaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voos_Agendados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllDay = table.Column<bool>(type: "bit", nullable: false),
                    Editable = table.Column<bool>(type: "bit", nullable: false),
                    DurationEditable = table.Column<bool>(type: "bit", nullable: false),
                    BackgroundColor = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    TextColor = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    AeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voos_Agendados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voos_Agendados_Aeronaves_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "Aeronaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contas_Pagar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorPagar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas_Pagar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Pagar_Contas_Id",
                        column: x => x.Id,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contas_Receber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorReceber = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorRecebido = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DataRecebimento = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas_Receber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Receber_Contas_Id",
                        column: x => x.Id,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RG = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    CANAC = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    TotalVoado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidadeCMA = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Pessoas_Id",
                        column: x => x.Id,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Pessoas_Id",
                        column: x => x.Id,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAdmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDemissao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoColaborador = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    CANAC = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TipoVinculo = table.Column<int>(type: "int", nullable: false),
                    RG = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    OrgaoEmissor = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    TituloEleitor = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    NumeroPis = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    NumeroCtps = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    NumeroCnh = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Pessoas_Id",
                        column: x => x.Id,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Pessoas_Id",
                        column: x => x.Id,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suprimento_Movimentacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    TipoMovimentacaoEnum = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suprimento_Movimentacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suprimento_Movimentacoes_Suprimentos_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Suprimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo_Multas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutoInfracao = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Responsavel = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Classificacao = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Situacao = table.Column<bool>(type: "bit", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo_Multas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_Multas_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Itens_OrdensServico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OrdemServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens_OrdensServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_OrdensServico_Ordens_Servico_OrdemServicoId",
                        column: x => x.OrdemServicoId,
                        principalTable: "Ordens_Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_OrdensServico_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alunos_Turmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInscricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diarios_Bordo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Base = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    De = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    Para = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    HoraAcionamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraDecolagem = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraPouso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraCorte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalDiurno = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalNoturno = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalIfr = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalNavegacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalDecimal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDecPouso = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAcionamentoCorte = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pousos = table.Column<int>(type: "int", nullable: false),
                    Pob = table.Column<int>(type: "int", nullable: false),
                    CombustivelDecolagem = table.Column<int>(type: "int", nullable: false),
                    NaturezaVoo = table.Column<int>(type: "int", nullable: false),
                    PreVooResponsavel = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    PosVooResponsavel = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    Discrepancias = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    AcoesCorretivas = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    AeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComandanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CopilotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MecanicoResponsavelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diarios_Bordo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diarios_Bordo_Aeronaves_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "Aeronaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diarios_Bordo_Colaboradores_ComandanteId",
                        column: x => x.ComandanteId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diarios_Bordo_Colaboradores_CopilotoId",
                        column: x => x.CopilotoId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diarios_Bordo_Colaboradores_MecanicoResponsavelId",
                        column: x => x.MecanicoResponsavelId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo_Gastos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Situacao = table.Column<bool>(type: "bit", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MotoristaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo_Gastos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_Gastos_Colaboradores_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculo_Gastos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voos_Instrucao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TempoVoo = table.Column<double>(type: "float", nullable: false),
                    Avaliacao = table.Column<bool>(type: "bit", nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstrutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voos_Instrucao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voos_Instrucao_Aeronaves_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "Aeronaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voos_Instrucao_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voos_Instrucao_Colaboradores_InstrutorId",
                        column: x => x.InstrutorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aeronaves_Matricula",
                table: "Aeronaves",
                column: "Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aeronaves_Abastecimentos_AeronaveId",
                table: "Aeronaves_Abastecimentos",
                column: "AeronaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Aeronaves_Tarifas_AeronaveId",
                table: "Aeronaves_Tarifas",
                column: "AeronaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Turmas_AlunoId",
                table: "Alunos_Turmas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Turmas_TurmaId",
                table: "Alunos_Turmas",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_CodigoBarras",
                table: "Contas",
                column: "CodigoBarras",
                unique: true,
                filter: "[CodigoBarras] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_Codigo",
                table: "Cursos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diarios_Bordo_AeronaveId",
                table: "Diarios_Bordo",
                column: "AeronaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Diarios_Bordo_ComandanteId",
                table: "Diarios_Bordo",
                column: "ComandanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Diarios_Bordo_CopilotoId",
                table: "Diarios_Bordo",
                column: "CopilotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Diarios_Bordo_MecanicoResponsavelId",
                table: "Diarios_Bordo",
                column: "MecanicoResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_FornecedorId",
                table: "Enderecos",
                column: "FornecedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Itens_OrdensServico_OrdemServicoId",
                table: "Itens_OrdensServico",
                column: "OrdemServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_OrdensServico_ServicoId",
                table: "Itens_OrdensServico",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordens_Servico_AeronaveId",
                table: "Ordens_Servico",
                column: "AeronaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordens_Servico_NumeroOrdem",
                table: "Ordens_Servico",
                column: "NumeroOrdem",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produtos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_Codigo",
                table: "Servicos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suprimento_Movimentacoes_ItemId",
                table: "Suprimento_Movimentacoes",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_CursoId",
                table: "Turmas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_Gastos_MotoristaId",
                table: "Veiculo_Gastos",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_Gastos_VeiculoId",
                table: "Veiculo_Gastos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_Multas_VeiculoId",
                table: "Veiculo_Multas",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_Agendados_AeronaveId",
                table: "Voos_Agendados",
                column: "AeronaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_Instrucao_AeronaveId",
                table: "Voos_Instrucao",
                column: "AeronaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_Instrucao_AlunoId",
                table: "Voos_Instrucao",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_Instrucao_InstrutorId",
                table: "Voos_Instrucao",
                column: "InstrutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeronaves_Abastecimentos");

            migrationBuilder.DropTable(
                name: "Aeronaves_Tarifas");

            migrationBuilder.DropTable(
                name: "Alunos_Turmas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Contas_Pagar");

            migrationBuilder.DropTable(
                name: "Contas_Receber");

            migrationBuilder.DropTable(
                name: "Diarios_Bordo");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Itens_OrdensServico");

            migrationBuilder.DropTable(
                name: "Legislacoes");

            migrationBuilder.DropTable(
                name: "Manuais_Empresa");

            migrationBuilder.DropTable(
                name: "Manuais_Voo");

            migrationBuilder.DropTable(
                name: "Oficios_Emitidos");

            migrationBuilder.DropTable(
                name: "Oficios_Recebidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Suprimento_Movimentacoes");

            migrationBuilder.DropTable(
                name: "Veiculo_Gastos");

            migrationBuilder.DropTable(
                name: "Veiculo_Multas");

            migrationBuilder.DropTable(
                name: "Voos_Agendados");

            migrationBuilder.DropTable(
                name: "Voos_Instrucao");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Ordens_Servico");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Suprimentos");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Aeronaves");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
