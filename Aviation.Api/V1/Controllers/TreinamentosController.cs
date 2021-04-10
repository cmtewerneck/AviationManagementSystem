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
    [Route("api/v{version:apiVersion}/treinamentos")]
    public class TreinamentosController : MainController
    {
        private readonly ITreinamentoRepository _treinamentoRepository;
        private readonly ITreinamentoService _treinamentoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public TreinamentosController(INotificador notificador,
                                  ITreinamentoRepository treinamentoRepository,
                                  ITreinamentoService treinamentoService, 
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _treinamentoRepository = treinamentoRepository;
            _treinamentoService = treinamentoService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Treinamento", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<TreinamentoViewModel>> Adicionar(TreinamentoViewModel treinamentoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

           await _treinamentoService.Adicionar(_mapper.Map<Treinamento>(treinamentoViewModel));

            return CustomResponse(treinamentoViewModel);
        }
       
        [ClaimsAuthorize("Treinamento", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, TreinamentoViewModel treinamentoViewModel)
        {
            if (id != treinamentoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var treinamentoAtualizacao = await ObterTreinamento(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            treinamentoAtualizacao.DataInicio = treinamentoViewModel.DataInicio;
            treinamentoAtualizacao.DataTermino = treinamentoViewModel.DataTermino;
            treinamentoAtualizacao.ClassificacaoTreinamento = treinamentoViewModel.ClassificacaoTreinamento;
            treinamentoAtualizacao.TipoTreinamento = treinamentoViewModel.TipoTreinamento;
            treinamentoAtualizacao.TipoClasse = treinamentoViewModel.TipoClasse;
            treinamentoAtualizacao.ModeloAeronave = treinamentoViewModel.ModeloAeronave;
            treinamentoAtualizacao.Instrutor = treinamentoViewModel.Instrutor;
            treinamentoAtualizacao.Numero = treinamentoViewModel.Numero;
            treinamentoAtualizacao.CargaHoraria = treinamentoViewModel.CargaHoraria;
            treinamentoAtualizacao.TripulanteId = treinamentoViewModel.TripulanteId;
            treinamentoAtualizacao.CategoriaId = treinamentoViewModel.CategoriaId;

            await _treinamentoService.Atualizar(_mapper.Map<Treinamento>(treinamentoAtualizacao));

            return CustomResponse(treinamentoViewModel);
        }

        [ClaimsAuthorize("Treinamento", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TreinamentoViewModel>> Excluir(Guid id)
        {
            var treinamento = await ObterTreinamento(id);

            if (treinamento == null) return NotFound();

            await _treinamentoService.Remover(id);

            return CustomResponse(treinamento);
        }

        [ClaimsAuthorize("Treinamento", "Atualizar")]
        [HttpPut("encerrar/{id:guid}")]
        public async Task<ActionResult<TreinamentoViewModel>> EncerrarTreinamento(Guid id)
        {
            var treinamentoAtualizacao = await ObterTreinamento(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            treinamentoAtualizacao.DataTermino = DateTime.Now;

            await _treinamentoService.Atualizar(_mapper.Map<Treinamento>(treinamentoAtualizacao));

            return CustomResponse(treinamentoAtualizacao);
        }

        [ClaimsAuthorize("Treinamento", "Atualizar")]
        [HttpPut("reabrir/{id:guid}")]
        public async Task<ActionResult<TreinamentoViewModel>> ReabrirTreinamento(Guid id)
        {
            var treinamentoAtualizacao = await ObterTreinamento(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            treinamentoAtualizacao.DataTermino = null;

            await _treinamentoService.Atualizar(_mapper.Map<Treinamento>(treinamentoAtualizacao));

            return CustomResponse(treinamentoAtualizacao);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Treinamento", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<TreinamentoViewModel>> ObterTodos()
        {
            var entidade = await _treinamentoRepository.ObterTreinamentosColaboradoresCategorias();
            return _mapper.Map<IEnumerable<TreinamentoViewModel>>(entidade);
        }

        [ClaimsAuthorize("Treinamento", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TreinamentoViewModel>> ObterPorId(Guid id)
        {
            var treinamento = await ObterTreinamento(id);

            if (treinamento == null) return NotFound();

            return treinamento;
        }

        private async Task<TreinamentoViewModel> ObterTreinamento(Guid id)
        {
            return _mapper.Map<TreinamentoViewModel>(await _treinamentoRepository.ObterTreinamentoColaboradorCategoria(id));
        }
        #endregion
    }
}