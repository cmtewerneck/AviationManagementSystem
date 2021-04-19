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
    [Route("api/v{version:apiVersion}/diarias-tripulantes")]
    public class DiariasTripulantesController : MainController
    {
        private readonly IDiariaTripulanteRepository _diariaTripulanteRepository;
        private readonly IDiariaTripulanteService _diariaTripulanteService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public DiariasTripulantesController(INotificador notificador,
                                  IDiariaTripulanteRepository diariaTripulanteRepository,
                                  IDiariaTripulanteService diariaTripulanteService, 
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _diariaTripulanteRepository = diariaTripulanteRepository;
            _diariaTripulanteService = diariaTripulanteService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Tripulante", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<DiariaTripulanteViewModel>> Adicionar(DiariaTripulanteViewModel diariaTripulanteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

           await _diariaTripulanteService.Adicionar(_mapper.Map<DiariaTripulante>(diariaTripulanteViewModel));

            return CustomResponse(diariaTripulanteViewModel);
        }
       
        [ClaimsAuthorize("Tripulante", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, DiariaTripulanteViewModel diariaTripulanteViewModel)
        {
            if (id != diariaTripulanteViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var diariaTripulanteAtualizacao = await ObterDiariaTripulante(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            diariaTripulanteAtualizacao.DataInicio = diariaTripulanteViewModel.DataInicio;
            diariaTripulanteAtualizacao.DataFim = diariaTripulanteViewModel.DataFim;
            diariaTripulanteAtualizacao.Valor = diariaTripulanteViewModel.Valor;
            diariaTripulanteAtualizacao.Finalidade = diariaTripulanteViewModel.Finalidade;
            diariaTripulanteAtualizacao.Status = diariaTripulanteViewModel.Status;
            diariaTripulanteAtualizacao.FormaPagamento = diariaTripulanteViewModel.FormaPagamento;
            diariaTripulanteAtualizacao.TripulanteId = diariaTripulanteViewModel.TripulanteId;

            await _diariaTripulanteService.Atualizar(_mapper.Map<DiariaTripulante>(diariaTripulanteAtualizacao));

            return CustomResponse(diariaTripulanteViewModel);
        }

        [ClaimsAuthorize("Tripulante", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<DiariaTripulanteViewModel>> Excluir(Guid id)
        {
            var diaria = await ObterDiariaTripulante(id);

            if (diaria == null) return NotFound();

            await _diariaTripulanteService.Remover(id);

            return CustomResponse(diaria);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Tripulante", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<DiariaTripulanteViewModel>> ObterTodos()
        {
            var entidade = await _diariaTripulanteRepository.ObterDiariasTripulantes();
            return _mapper.Map<IEnumerable<DiariaTripulanteViewModel>>(entidade);
        }

        [ClaimsAuthorize("Tripulante", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DiariaTripulanteViewModel>> ObterPorId(Guid id)
        {
            var diaria = await ObterDiariaTripulante(id);

            if (diaria == null) return NotFound();

            return diaria;
        }

        private async Task<DiariaTripulanteViewModel> ObterDiariaTripulante(Guid id)
        {
            return _mapper.Map<DiariaTripulanteViewModel>(await _diariaTripulanteRepository.ObterDiariaTripulante(id));
        }
        #endregion
    }
}