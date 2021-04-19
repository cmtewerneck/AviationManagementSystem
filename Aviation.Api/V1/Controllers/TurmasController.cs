﻿using AutoMapper;
using AviationManagementApi.Api.Controllers;
using AviationManagementApi.Api.Extensions;
using AviationManagementApi.Api.ViewModels;
using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        [ClaimsAuthorize("Turma", "Atualizar")]
        [HttpPost("alunos/gerarCertificado/{id:guid}")]
        public async Task<ActionResult<AlunoTurmaViewModel>> GerarCertificadoAluno (Guid id)
        {
            var alunoTurma = await ObterAlunoTurma(id);

            using (var doc = new PdfSharp.Pdf.PdfDocument())
            {
                var page = doc.AddPage();
                var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
                var textFormatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);
                var font = new PdfSharp.Drawing.XFont("Arial", 14);

                textFormatter.DrawString("Que belo texto!", font, PdfSharp.Drawing.XBrushes.Red, new PdfSharp.Drawing.XRect(0, 0, page.Width, page.Height));

                doc.Save(alunoTurma.NomeAluno + ".pdf");
            }

            return CustomResponse(alunoTurma);
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
