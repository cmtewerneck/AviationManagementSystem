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

namespace AviationManagementApi.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/cursos")]
    public class CursosController : MainController
    {
        private readonly ICursoRepository _cursosRepository;
        private readonly ICursoServices _cursosService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public CursosController(INotificador notificador,
                                  ICursoRepository cursosRepository,
                                  ICursoServices cursosService,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _cursosRepository = cursosRepository;
            _cursosService = cursosService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Curso", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<CursoViewModel>> Adicionar(CursoViewModel cursoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cursosService.Adicionar(_mapper.Map<Curso>(cursoViewModel));

            return CustomResponse(cursoViewModel);
        }

        [ClaimsAuthorize("Curso", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, CursoViewModel cursoViewModel)
        {
            if (id != cursoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var cursoAtualizacao = await ObterCurso(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState); 

            cursoAtualizacao.Codigo = cursoViewModel.Codigo;
            cursoAtualizacao.Descricao = cursoViewModel.Descricao;

            await _cursosService.Atualizar(_mapper.Map<Curso>(cursoAtualizacao));

            return CustomResponse(cursoViewModel);
        }

        [ClaimsAuthorize("Curso", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CursoViewModel>> Excluir(Guid id)
        {
            var curso = await ObterCurso(id);

            if (curso == null) return NotFound();

            await _cursosService.Remover(id);

            return CustomResponse(curso);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Curso", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<CursoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CursoViewModel>>(await _cursosRepository.ObterTodos());
        }

        [ClaimsAuthorize("Curso", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CursoViewModel>> ObterPorId(Guid id)
        {
            var cursoViewModel = await ObterCurso(id);

            if (cursoViewModel == null) return NotFound();

            return cursoViewModel;
        }

        private async Task<CursoViewModel> ObterCurso(Guid id)
        {
            return _mapper.Map<CursoViewModel>(await _cursosRepository.ObterPorId(id));
            //return _mapper.Map<CursoViewModel>(await _cursosRepository.ObterCursoPorId(id));
        }
        #endregion
    }
}