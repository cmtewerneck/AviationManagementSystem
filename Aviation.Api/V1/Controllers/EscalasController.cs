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
    [Route("api/v{version:apiVersion}/escalas")]
    public class EscalasController : MainController
    {
        private readonly IEscalaRepository _escalaRepository;
        private readonly IEscalaService _escalaService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public EscalasController(INotificador notificador,
                                  IEscalaRepository escalaRepository,
                                  IEscalaService escalaService, 
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _escalaRepository = escalaRepository;
            _escalaService = escalaService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Escala", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<EscalaViewModel>> Adicionar(EscalaViewModel escalaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

           await _escalaService.Adicionar(_mapper.Map<Escala>(escalaViewModel));

            return CustomResponse(escalaViewModel);
        }
       
        [ClaimsAuthorize("Escala", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, EscalaViewModel escalaViewModel)
        {
            if (id != escalaViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var escalaAtualizacao = await ObterEscalaTripulante(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            escalaAtualizacao.Data = escalaViewModel.Data;
            escalaAtualizacao.Status = escalaViewModel.Status;
            escalaAtualizacao.TripulanteId = escalaViewModel.TripulanteId;

            await _escalaService.Atualizar(_mapper.Map<Escala>(escalaAtualizacao));

            return CustomResponse(escalaViewModel);
        }

        [ClaimsAuthorize("Escala", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EscalaViewModel>> Excluir(Guid id)
        {
            var escala = await ObterEscalaTripulante(id);

            if (escala == null) return NotFound();

            await _escalaService.Remover(id);

            return CustomResponse(escala);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Escala", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<EscalaViewModel>> ObterTodos()
        {
            var entidade = await _escalaRepository.ObterEscalasTripulantes();
            return _mapper.Map<IEnumerable<EscalaViewModel>>(entidade);
        }

        [ClaimsAuthorize("Escala", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EscalaViewModel>> ObterPorId(Guid id)
        {
            var escala = await ObterEscalaTripulante(id);

            if (escala == null) return NotFound();

            return escala;
        }

        private async Task<EscalaViewModel> ObterEscalaTripulante(Guid id)
        {
            return _mapper.Map<EscalaViewModel>(await _escalaRepository.ObterEscalaTripulante(id));
        }
        #endregion
    }
}