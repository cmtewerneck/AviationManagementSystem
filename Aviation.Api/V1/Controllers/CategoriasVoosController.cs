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
    [Route("api/v{version:apiVersion}/categorias-voos")]
    public class CategoriasVoosController : MainController
    {
        private readonly ICategoriaVooRepository _categoriaVooRepository;
        private readonly ICategoriaVooService _categoriaVooService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public CategoriasVoosController(INotificador notificador,
                                  ICategoriaVooRepository categoriaVooRepository,
                                  ICategoriaVooService categoriaVooService,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _categoriaVooRepository = categoriaVooRepository;
            _categoriaVooService = categoriaVooService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Agendamento", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<CategoriaVooViewModel>> Adicionar(CategoriaVooViewModel categoriaVooViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoriaVooService.Adicionar(_mapper.Map<CategoriaVoo>(categoriaVooViewModel));

            return CustomResponse(categoriaVooViewModel);
        }

        [ClaimsAuthorize("Agendamento", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, CategoriaVooViewModel categoriaVooViewModel)
        {
            if (id != categoriaVooViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var categoriaVooAtualizacao = await ObterCategoriaVoo(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            categoriaVooAtualizacao.Codigo = categoriaVooViewModel.Codigo;
            categoriaVooAtualizacao.Descricao = categoriaVooViewModel.Descricao;

            await _categoriaVooService.Atualizar(_mapper.Map<CategoriaVoo>(categoriaVooAtualizacao));

            return CustomResponse(categoriaVooViewModel);
        }

        [ClaimsAuthorize("Agendamento", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CategoriaVooViewModel>> Excluir(Guid id)
        {
            var categoriaVoo = await ObterCategoriaVoo(id);

            if (categoriaVoo == null) return NotFound();

            await _categoriaVooService.Remover(id);

            return CustomResponse(categoriaVoo);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Agendamento", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<CategoriaVooViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaVooViewModel>>(await _categoriaVooRepository.ObterTodos());
        }

        [ClaimsAuthorize("Agendamento", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoriaVooViewModel>> ObterPorId(Guid id)
        {
            var categoriaVoo = await ObterCategoriaVoo(id);

            if (categoriaVoo == null) return NotFound();

            return categoriaVoo;
        }

        private async Task<CategoriaVooViewModel> ObterCategoriaVoo(Guid id)
        {
            return _mapper.Map<CategoriaVooViewModel>(await _categoriaVooRepository.ObterPorId(id));
        }
        #endregion
    }
}