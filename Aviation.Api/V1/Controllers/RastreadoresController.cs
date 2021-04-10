using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AviationManagementApi.Api.ViewModels;
using AviationManagementApi.Business.Interfaces;
using AutoMapper;
using AviationManagementApi.Business.Models;
using Microsoft.AspNetCore.Authorization;
using AviationManagementApi.Api.Extensions;
using AviationManagementApi.Api.Controllers;
using System.IO;

namespace AviationManagementApi.App.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/rastreadores")]
    public class RastreadoresController : MainController
    {
        private readonly IRastreadorRepository _rastreadorRepository;
        private readonly IRastreadorService _rastreadorService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public RastreadoresController(IRastreadorRepository rastreadorRepository,
                                  IRastreadorService rastreadorService,
                                  IMapper mapper,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _rastreadorRepository = rastreadorRepository;
            _mapper = mapper;
            _rastreadorService = rastreadorService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Rastreador", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<RastreadorViewModel>> Adicionar(RastreadorViewModel rastreadorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _rastreadorService.Adicionar(_mapper.Map<Rastreador>(rastreadorViewModel));

            return CustomResponse(rastreadorViewModel);
        }

        [ClaimsAuthorize("Rastreador", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<RastreadorViewModel>> Atualizar(Guid id, RastreadorViewModel rastreadorViewModel)
        {
            if (id != rastreadorViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var rastreadorAtualizacao = await ObterRastreador(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            rastreadorAtualizacao.Codigo = rastreadorViewModel.Codigo;
            rastreadorAtualizacao.Modelo = rastreadorViewModel.Modelo;
            rastreadorAtualizacao.AeronaveId = rastreadorViewModel.AeronaveId;

            await _rastreadorService.Atualizar(_mapper.Map<Rastreador>(rastreadorAtualizacao));

            return CustomResponse(rastreadorViewModel);
        }

        [ClaimsAuthorize("Rastreador", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<RastreadorViewModel>> Excluir(Guid id)
        {
            var rastreador = await ObterRastreador(id);

            if (rastreador == null)
            {
                NotificarErro("O id do rastreador não foi encontrado.");
                return CustomResponse(rastreador);
            }

            await _rastreadorService.Remover(id);

            return CustomResponse(rastreador);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Rastreador", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<RastreadorViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<RastreadorViewModel>>(await _rastreadorRepository.ObterRastreadoresAeronaves());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RastreadorViewModel>> ObterRastreadorPorId(Guid id)
        {
            var rastreador = _mapper.Map<RastreadorViewModel>(await _rastreadorRepository.ObterRastreadorAeronave(id));

            if (rastreador == null) return NotFound();

            return rastreador;
        }

        private async Task<RastreadorViewModel> ObterRastreador(Guid id)
        {
            return _mapper.Map<RastreadorViewModel>(await _rastreadorRepository.ObterPorId(id));
        }
        #endregion
    }
}