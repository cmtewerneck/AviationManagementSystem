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

namespace AviationManagementApi.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/diarios-bordo")]
    public class DiariosBordoController : MainController
    {
        private readonly IDiarioBordoRepository _diarioBordoRepository;
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly IDiarioBordoServices _diarioBordoService;
        private readonly IAeronaveServices _aeronaveService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public DiariosBordoController(INotificador notificador,
                                      IAeronaveRepository aeronaveRepository,
                                      IAeronaveServices aeronaveService,
                                      IDiarioBordoRepository diarioBordoRepository,
                                      IDiarioBordoServices diarioBordoService,
                                      IMapper mapper,
                                      IUser user) : base(notificador, user)
        {
            _diarioBordoRepository = diarioBordoRepository;
            _diarioBordoService = diarioBordoService;
            _aeronaveRepository = aeronaveRepository;
            _aeronaveService = aeronaveService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Diario", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<DiarioBordoViewModel>> Adicionar(DiarioBordoViewModel diarioBordoViewModel)
        {
            //diarioBordoViewModel.HoraAcionamento = diarioBordoViewModel.HoraAcionamento.AddHours(-3);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _diarioBordoService.Adicionar(_mapper.Map<DiarioBordo>(diarioBordoViewModel));

            // PARTE DA AERONAVE
            var aeronaveAtualizacao = await ObterAeronave(diarioBordoViewModel.AeronaveId);
            aeronaveAtualizacao.HorasTotais += diarioBordoViewModel.TotalAcionamentoCorte;
            await _aeronaveService.Atualizar(_mapper.Map<Aeronave>(aeronaveAtualizacao));

            return CustomResponse(diarioBordoViewModel);
        }

        [ClaimsAuthorize("Diario", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, DiarioBordoViewModel diarioBordoViewModel)
        {
            if (id != diarioBordoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var diarioBordoAtualizacao = await ObterDiarioBordo(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            diarioBordoAtualizacao.Data = diarioBordoViewModel.Data;
            diarioBordoAtualizacao.Base = diarioBordoViewModel.Base;
            diarioBordoAtualizacao.De = diarioBordoViewModel.De;
            diarioBordoAtualizacao.Para = diarioBordoViewModel.Para;
            diarioBordoAtualizacao.HoraAcionamento = diarioBordoViewModel.HoraAcionamento;
            diarioBordoAtualizacao.HoraDecolagem = diarioBordoViewModel.HoraDecolagem;
            diarioBordoAtualizacao.HoraPouso = diarioBordoViewModel.HoraPouso;
            diarioBordoAtualizacao.HoraCorte = diarioBordoViewModel.HoraCorte;
            diarioBordoAtualizacao.TotalDiurno = diarioBordoViewModel.TotalDiurno;
            diarioBordoAtualizacao.TotalNoturno = diarioBordoViewModel.TotalNoturno;
            diarioBordoAtualizacao.TotalIfr = diarioBordoViewModel.TotalIfr;
            diarioBordoAtualizacao.TotalNavegacao = diarioBordoViewModel.TotalNavegacao;
            diarioBordoAtualizacao.TotalDecimal = diarioBordoViewModel.TotalDecimal;
            diarioBordoAtualizacao.TotalDecPouso = diarioBordoViewModel.TotalDecPouso;
            diarioBordoAtualizacao.TotalAcionamentoCorte = diarioBordoViewModel.TotalAcionamentoCorte;
            diarioBordoAtualizacao.Pousos = diarioBordoViewModel.Pousos;
            diarioBordoAtualizacao.Pob = diarioBordoViewModel.Pob;
            diarioBordoAtualizacao.CombustivelDecolagem = diarioBordoViewModel.CombustivelDecolagem;
            diarioBordoAtualizacao.NaturezaVoo = diarioBordoViewModel.NaturezaVoo;
            diarioBordoAtualizacao.PreVooResponsavel = diarioBordoViewModel.PreVooResponsavel;
            diarioBordoAtualizacao.PosVooResponsavel = diarioBordoViewModel.PosVooResponsavel;
            diarioBordoAtualizacao.Observacoes = diarioBordoViewModel.Observacoes;
            diarioBordoAtualizacao.Discrepancias = diarioBordoViewModel.Discrepancias;
            diarioBordoAtualizacao.AcoesCorretivas = diarioBordoViewModel.AcoesCorretivas;
            diarioBordoAtualizacao.AeronaveId = diarioBordoViewModel.AeronaveId;
            diarioBordoAtualizacao.ComandanteId = diarioBordoViewModel.ComandanteId;
            diarioBordoAtualizacao.CopilotoId = diarioBordoViewModel.CopilotoId;
            diarioBordoAtualizacao.MecanicoResponsavelId = diarioBordoViewModel.MecanicoResponsavelId;

            await _diarioBordoService.Atualizar(_mapper.Map<DiarioBordo>(diarioBordoAtualizacao));

            return CustomResponse(diarioBordoViewModel);
        }

        [ClaimsAuthorize("Diario", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<DiarioBordoViewModel>> Excluir(Guid id)
        {
            var diario = await ObterDiarioBordo(id);

            if (diario == null) return NotFound();

            await _diarioBordoService.Remover(id);

            return CustomResponse(diario);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Diario", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<DiarioBordoViewModel>> ObterTodos()
        {
            var entidade = await _diarioBordoRepository.ObterDiariosAeronavesColaboradores();
            return _mapper.Map<IEnumerable<DiarioBordoViewModel>>(entidade);
        }

        [ClaimsAuthorize("Diario", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DiarioBordoViewModel>> ObterPorId(Guid id)
        {
            var diarioBordoViewModel = await ObterDiarioBordo(id);

            if (diarioBordoViewModel == null) return NotFound();

            return diarioBordoViewModel;
        }

        private async Task<DiarioBordoViewModel> ObterDiarioBordo(Guid id)
        {
            return _mapper.Map<DiarioBordoViewModel>(await _diarioBordoRepository.ObterDiarioAeronaveColaboradores(id));
        }

        private async Task<AeronaveViewModel> ObterAeronave(Guid id)
        {
            return _mapper.Map<AeronaveViewModel>(await _aeronaveRepository.ObterPorId(id));
        }
        #endregion
    }
}