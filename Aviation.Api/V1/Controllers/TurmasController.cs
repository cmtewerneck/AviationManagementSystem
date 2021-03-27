using AutoMapper;
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
        public async Task<ActionResult<TurmaViewModel>> AdicionarAlunoTurma(AlunoTurmaViewModel alunoTurmaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            alunoTurmaViewModel.DataInscricao = DateTime.Now;

            await _alunoTurmaService.Adicionar(_mapper.Map<AlunoTurma>(alunoTurmaViewModel));

            return CustomResponse(alunoTurmaViewModel);
        }

        [ClaimsAuthorize("Turma", "Atualizar")]
        [HttpPut("encerrar/{id:guid}")]
        public async Task<ActionResult<TurmaViewModel>> EncerrarTurma(Guid id, TurmaViewModel turmaViewModel)
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

            turmaAtualizacao.DataTermino = DateTime.Now;

            await _turmaService.Atualizar(_mapper.Map<Turma>(turmaAtualizacao));

            return CustomResponse(turmaViewModel);
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
            var turma = _mapper.Map<TurmaViewModel>(await _turmaRepository.ObterTurmaCursoAlunos(id));

            if (turma == null) return NotFound();

            return turma;
        }

        private async Task<TurmaViewModel> ObterTurma(Guid id)
        {
            return _mapper.Map<TurmaViewModel>(await _turmaRepository.ObterPorId(id));
        }
        #endregion
    }
}
