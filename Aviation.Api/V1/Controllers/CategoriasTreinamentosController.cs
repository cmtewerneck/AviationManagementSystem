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
    [Route("api/v{version:apiVersion}/categorias-treinamentos")]
    public class CategoriasTreinamentosController : MainController
    {
        private readonly ICategoriaTreinamentoRepository _categoriaTreinamentoRepository;
        private readonly ICategoriaTreinamentoService _categoriaTreinamentoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public CategoriasTreinamentosController(INotificador notificador,
                                  ICategoriaTreinamentoRepository categoriaTreinamentoRepository,
                                  ICategoriaTreinamentoService categoriaTreinamentoService,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _categoriaTreinamentoRepository = categoriaTreinamentoRepository;
            _categoriaTreinamentoService = categoriaTreinamentoService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Treinamento", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<CategoriaTreinamentoViewModel>> Adicionar(CategoriaTreinamentoViewModel categoriaTreinamentoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoriaTreinamentoService.Adicionar(_mapper.Map<CategoriaTreinamento>(categoriaTreinamentoViewModel));

            return CustomResponse(categoriaTreinamentoViewModel);
        }

        [ClaimsAuthorize("Treinamento", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, CategoriaTreinamentoViewModel categoriaTreinamentoViewModel)
        {
            if (id != categoriaTreinamentoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var categoriaTreinamentoAtualizacao = await ObterCategoriaTreinamento(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            categoriaTreinamentoAtualizacao.Codigo = categoriaTreinamentoViewModel.Codigo;
            categoriaTreinamentoAtualizacao.Descricao = categoriaTreinamentoViewModel.Descricao;

            await _categoriaTreinamentoService.Atualizar(_mapper.Map<CategoriaTreinamento>(categoriaTreinamentoAtualizacao));

            return CustomResponse(categoriaTreinamentoViewModel);
        }

        [ClaimsAuthorize("Treinamento", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CategoriaTreinamentoViewModel>> Excluir(Guid id)
        {
            var categoriaTreinamento = await ObterCategoriaTreinamento(id);

            if (categoriaTreinamento == null) return NotFound();

            await _categoriaTreinamentoService.Remover(id);

            return CustomResponse(categoriaTreinamento);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Treinamento", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<CategoriaTreinamentoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaTreinamentoViewModel>>(await _categoriaTreinamentoRepository.ObterTodos());
        }

        [ClaimsAuthorize("Treinamento", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoriaTreinamentoViewModel>> ObterPorId(Guid id)
        {
            var categoriaTreinamento = await ObterCategoriaTreinamento(id);

            if (categoriaTreinamento == null) return NotFound();

            return categoriaTreinamento;
        }

        private async Task<CategoriaTreinamentoViewModel> ObterCategoriaTreinamento(Guid id)
        {
            return _mapper.Map<CategoriaTreinamentoViewModel>(await _categoriaTreinamentoRepository.ObterPorId(id));
            //return _mapper.Map<CursoViewModel>(await _cursosRepository.ObterCursoPorId(id));
        }
        #endregion
    }
}