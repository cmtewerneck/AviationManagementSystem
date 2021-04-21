using AutoMapper;
using AviationManagementApi.Api.Controllers;
using AviationManagementApi.Api.Extensions;
using AviationManagementApi.Api.ViewModels;
using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace AviationManagementApi.App.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/turmas")]
    public class TurmasController : MainController
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        private readonly ITurmaServices _turmaService;
        private readonly IAlunoTurmaServices _alunoTurmaService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public TurmasController(ITurmaRepository turmaRepository,
                                IAlunoTurmaRepository alunoTurmaRepository,
                                IMapper mapper,
                                ITurmaServices turmaService,
                                IAlunoTurmaServices alunoTurmaService,
                                INotificador notificador, IUser user) : base(notificador, user)
        {
            _turmaRepository = turmaRepository;
            _alunoTurmaRepository = alunoTurmaRepository;
            _mapper = mapper;
            _turmaService = turmaService;
            _alunoTurmaService = alunoTurmaService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Turma", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<TurmaViewModel>> Adicionar(TurmaViewModel turmaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _turmaService.Adicionar(_mapper.Map<Turma>(turmaViewModel));

            return CustomResponse(turmaViewModel);
        }

        [ClaimsAuthorize("Turma", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TurmaViewModel>> Atualizar(Guid id, TurmaViewModel turmaViewModel)
        {
            if (id != turmaViewModel.Id)
            {
                NotificarErro("O id informado é diferente do id da requisição.");
                return CustomResponse();
            }

            var turmaAtualizacao = await ObterTurma(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            turmaAtualizacao.Codigo = turmaViewModel.Codigo;
            turmaAtualizacao.DataInicio = turmaViewModel.DataInicio;
            turmaAtualizacao.DataTermino = turmaViewModel.DataTermino;
            turmaAtualizacao.Inscricao = turmaViewModel.Inscricao;
            turmaAtualizacao.Mensalidade = turmaViewModel.Mensalidade;
            turmaAtualizacao.CursoId = turmaViewModel.CursoId;

            await _turmaService.Atualizar(_mapper.Map<Turma>(turmaAtualizacao));

            return CustomResponse(turmaViewModel);
        }

        [ClaimsAuthorize("Turma", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TurmaViewModel>> Excluir(Guid id)
        {
            var turmaViewModel = await ObterTurma(id);

            if (turmaViewModel == null)
            {
                NotificarErro("O id da turma não foi encontrado.");
                return CustomResponse(turmaViewModel);
            }

            await _turmaService.Remover(id);

            return CustomResponse(turmaViewModel);
        }

        // ALUNO TURMA
        [ClaimsAuthorize("Turma", "Adicionar")]
        [HttpPost("alunos")]
        public async Task<ActionResult<AlunoTurmaViewModel>> AdicionarAlunoTurma(AlunoTurmaViewModel alunoTurmaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            alunoTurmaViewModel.DataInscricao = DateTime.Now;
            alunoTurmaViewModel.SituacaoAluno = 1;

            await _alunoTurmaService.Adicionar(_mapper.Map<AlunoTurma>(alunoTurmaViewModel));

            return CustomResponse(alunoTurmaViewModel);
        }

        [ClaimsAuthorize("Turma", "Atualizar")]
        [HttpPut("alunos/aprovar/{id:guid}")]
        public async Task<ActionResult<AlunoTurmaViewModel>> AprovarAluno(Guid id)
        {
            var alunoTurmaAtualizacao = await ObterAlunoTurma(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            // ALTERAÇÃO PARA APROVADO!! ENUM 2
            alunoTurmaAtualizacao.SituacaoAluno = 2;

            await _alunoTurmaService.Atualizar(_mapper.Map<AlunoTurma>(alunoTurmaAtualizacao));

            return CustomResponse(alunoTurmaAtualizacao);
        }

        [ClaimsAuthorize("Turma", "Atualizar")]
        [HttpPut("alunos/reprovar/{id:guid}")]
        public async Task<ActionResult<AlunoTurmaViewModel>> ReprovarAluno(Guid id)
        {
            var alunoTurmaAtualizacao = await ObterAlunoTurma(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            // ALTERAÇÃO PARA APROVADO!! ENUM 2
            alunoTurmaAtualizacao.SituacaoAluno = 3;

            await _alunoTurmaService.Atualizar(_mapper.Map<AlunoTurma>(alunoTurmaAtualizacao));

            return CustomResponse(alunoTurmaAtualizacao);
        }

        [ClaimsAuthorize("Turma", "Atualizar")]
        [HttpPut("encerrar/{id:guid}")]
        public async Task<ActionResult<TurmaViewModel>> EncerrarTurma(Guid id)
        {
            var turmaAtualizacao = await ObterTurma(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            turmaAtualizacao.DataTermino = DateTime.Now;

            await _turmaService.Atualizar(_mapper.Map<Turma>(turmaAtualizacao));

            return CustomResponse(turmaAtualizacao);
        }

        [ClaimsAuthorize("Turma", "Atualizar")]
        [HttpPut("reabrir/{id:guid}")]
        public async Task<ActionResult<TurmaViewModel>> ReabrirTurma(Guid id)
        {
            var turmaAtualizacao = await ObterTurma(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            turmaAtualizacao.DataTermino = null;

            await _turmaService.Atualizar(_mapper.Map<Turma>(turmaAtualizacao));

            return CustomResponse(turmaAtualizacao);
        }

        // TESTE DO PDF
        //[ClaimsAuthorize("Turma", "Atualizar")]
        [AllowAnonymous]
        [HttpGet("alunos/gerarCertificado/{alunoTurmaId:guid}")]
        public FileResult GerarCertificadoAluno(Guid alunoTurmaId)
        {
            //var alunoTurma = ObterAlunoTurma(id);

            using (var doc = new PdfSharpCore.Pdf.PdfDocument())
            {
                // PÁGINA
                var page = doc.AddPage();
                page.Size = PdfSharpCore.PageSize.A4;
                page.Orientation = PdfSharpCore.PageOrientation.Landscape;
                page.Width = XUnit.FromMillimeter(297);
                page.Height = XUnit.FromMillimeter(210);
                // FIM CONFIGURAÇÃO PÁGINA

                var graphics = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page);
                var textFormatter = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                var font = new PdfSharpCore.Drawing.XFont("Arial", 14);
                var corFontePaginacao = PdfSharpCore.Drawing.XBrushes.Black;

                textFormatter.DrawString("Que belo texto!", font, PdfSharpCore.Drawing.XBrushes.Red, new PdfSharpCore.Drawing.XRect(0, 0, page.Width, page.Height));

                // PAGINADOR
                var qntPaginas = doc.PageCount;
                textFormatter.DrawString(qntPaginas.ToString(), new PdfSharpCore.Drawing.XFont("Arial", 10), corFontePaginacao, new PdfSharpCore.Drawing.XRect(578, 825, page.Width, page.Height));
                // FIM PAGINADOR

                // BACKGROUND
                var imagemPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/models/certificado_1.jpg");
               //@"C:\ProjetosGitHub\AviationManagementSystem\Aviation.Api\wwwroot\models\certificado_1.jpg";
                XImage imagem = XImage.FromFile(imagemPath);
                graphics.DrawImage(imagem, 0, 0, page.Width, page.Height);
                // FIM BACKGROUND

                var largura = page.Width;
                var altura = page.Height;

                textFormatter.DrawString("Certifico para os devidos fins, que FULANO DE TAL CPF 123.456.789-10, concluiu com êxito o curso de Piloto Privado de Avião nesta entidade, no período de 10/01/2021 à 12/01/2021, com carga horária de 360 horas.", font, corFontePaginacao, new PdfSharpCore.Drawing.XRect(130, 350, 570, page.Height));

                graphics.DrawLine(XPens.Black, 130, 490, 330, 490);
                textFormatter.DrawString("DIRETOR", font, corFontePaginacao, new PdfSharpCore.Drawing.XRect(200, 500, page.Width, page.Height));
                graphics.DrawLine(XPens.Black, 510, 490, 710, 490);
                textFormatter.DrawString("ALUNO", font, corFontePaginacao, new PdfSharpCore.Drawing.XRect(585, 500, page.Width, page.Height));

                using (MemoryStream stream = new MemoryStream())
                {
                    var contentType = "application/pdf";

                    doc.Save(stream, false);

                    var arquivoNome = "Texte.pdf";

                    return File(stream.ToArray(), contentType, arquivoNome);
                }
            }
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Turma", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<TurmaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TurmaViewModel>>(await _turmaRepository.ObterTurmasCursos());
        }

        [ClaimsAuthorize("Turma", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TurmaViewModel>> ObterTurmaPorId(Guid id)
        {
            var entity = await _turmaRepository.ObterTurmaCursoAlunos(id);
            var turma = _mapper.Map<TurmaViewModel>(entity);

            if (turma == null) return NotFound();

            return turma;
        }

        private async Task<TurmaViewModel> ObterTurma(Guid id)
        {
            return _mapper.Map<TurmaViewModel>(await _turmaRepository.ObterPorId(id));
        }

        private async Task<AlunoTurmaViewModel> ObterAlunoTurma(Guid id)
        {
            return _mapper.Map<AlunoTurmaViewModel>(await _alunoTurmaRepository.ObterPorId(id));
        }
        #endregion
    }
}
