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
    [Route("api/v{version:apiVersion}/voos-instrucao")]
    public class VoosInstrucoesController : MainController
    {
        private readonly IVooInstrucaoRepository _vooInstrucaoRepository;
        private readonly IVooInstrucaoServices _vooInstrucaoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public VoosInstrucoesController(INotificador notificador,
                                  IVooInstrucaoRepository vooInstrucaoRepository,
                                  IVooInstrucaoServices vooInstrucaoService,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _vooInstrucaoRepository = vooInstrucaoRepository;
            _vooInstrucaoService = vooInstrucaoService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Instrucao", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<VooInstrucaoViewModel>> Adicionar(VooInstrucaoViewModel vooInstrucaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _vooInstrucaoService.Adicionar(_mapper.Map<VooInstrucao>(vooInstrucaoViewModel));

            return CustomResponse(vooInstrucaoViewModel);
        }

        [ClaimsAuthorize("Instrucao", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, VooInstrucaoViewModel vooInstrucaoViewModel)
        {
            if (id != vooInstrucaoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var vooInstrucaoAtualizacao = await ObterVooInstrucao(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            vooInstrucaoAtualizacao.Data = vooInstrucaoViewModel.Data;
            vooInstrucaoAtualizacao.TempoVoo = vooInstrucaoViewModel.TempoVoo;
            vooInstrucaoAtualizacao.Avaliacao = vooInstrucaoViewModel.Avaliacao;
            vooInstrucaoAtualizacao.Observacoes = vooInstrucaoViewModel.Observacoes;

            await _vooInstrucaoService.Atualizar(_mapper.Map<VooInstrucao>(vooInstrucaoAtualizacao));

            return CustomResponse(vooInstrucaoViewModel);
        }

        [ClaimsAuthorize("Instrucao", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<VooInstrucaoViewModel>> Excluir(Guid id)
        {
            var vooInstrucao = await ObterVooInstrucao(id);

            if (vooInstrucao == null) return NotFound();

            await _vooInstrucaoService.Remover(id);

            return CustomResponse(vooInstrucao);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Instrucao", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<VooInstrucaoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<VooInstrucaoViewModel>>(await _vooInstrucaoRepository.ObterTodos());
        }

        [ClaimsAuthorize("Instrucao", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VooInstrucaoViewModel>> ObterPorId(Guid id)
        {
            var vooInstrucaoViewModel = await ObterVooInstrucao(id);

            if (vooInstrucaoViewModel == null) return NotFound();

            return vooInstrucaoViewModel;
        }

        private async Task<VooInstrucaoViewModel> ObterVooInstrucao(Guid id)
        {
            return _mapper.Map<VooInstrucaoViewModel>(await _vooInstrucaoRepository.ObterPorId(id));
        }
        #endregion
    }
}