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

namespace AviationManagementApi.App.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/suprimentos/movimentacoes")]
    public class SuprimentosMovimentacoesController : MainController
    {
        private readonly ISuprimentoMovimentacaoRepository _suprimentoMovimentacaoRepository;
        private readonly ISuprimentoRepository _suprimentoRepository;
        private readonly ISuprimentoMovimentacaoServices _suprimentoMovimentacaoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public SuprimentosMovimentacoesController(ISuprimentoMovimentacaoRepository suprimentoMovimentacaoRepository,
                                  ISuprimentoRepository suprimentoRepository,
                                  IMapper mapper,
                                  ISuprimentoMovimentacaoServices suprimentoMovimentacaoService,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _suprimentoMovimentacaoRepository = suprimentoMovimentacaoRepository;
            _suprimentoRepository = suprimentoRepository;
            _mapper = mapper;
            _suprimentoMovimentacaoService = suprimentoMovimentacaoService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Suprimento", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<SuprimentoMovimentacaoViewModel>> Adicionar(SuprimentoMovimentacaoViewModel suprimentoMovimentacaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _suprimentoMovimentacaoService.Adicionar(_mapper.Map<SuprimentoMovimentacao>(suprimentoMovimentacaoViewModel));

            return CustomResponse(suprimentoMovimentacaoViewModel);
        }

        [ClaimsAuthorize("Suprimento", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, SuprimentoMovimentacaoViewModel suprimentoMovimentacaoViewModel)
        {
            if (id != suprimentoMovimentacaoViewModel.Id)
            {
                NotificarErro("O id informado é diferente do id da requisição.");
                return CustomResponse();
            }

            var suprimentoMovimentacaoAtualizacao = await ObterSuprimentoMovimentacao(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            suprimentoMovimentacaoAtualizacao.Data = suprimentoMovimentacaoViewModel.Data;
            suprimentoMovimentacaoAtualizacao.Quantidade = suprimentoMovimentacaoViewModel.Quantidade;
            suprimentoMovimentacaoAtualizacao.TipoMovimentacaoEnum = suprimentoMovimentacaoViewModel.TipoMovimentacaoEnum;
            suprimentoMovimentacaoAtualizacao.ItemId = suprimentoMovimentacaoViewModel.ItemId;

            await _suprimentoMovimentacaoService.Atualizar(_mapper.Map<SuprimentoMovimentacao>(suprimentoMovimentacaoAtualizacao));

            return CustomResponse(suprimentoMovimentacaoViewModel);
        }

        [ClaimsAuthorize("Suprimento", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SuprimentoMovimentacaoViewModel>> Excluir(Guid id)
        {
            var suprimentoMovimentacaoViewModel = await ObterSuprimentoMovimentacaoPorId(id);

            // Implementar regra de negócio para somar ou subtrair ao excluir

            if (suprimentoMovimentacaoViewModel == null)
            {
                NotificarErro("O id da movimentação não foi encontrado.");
                return CustomResponse(suprimentoMovimentacaoViewModel);
            }

            await _suprimentoMovimentacaoService.Remover(id);

            return CustomResponse(suprimentoMovimentacaoViewModel);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Suprimento", "Adicionar")]
        [HttpGet]
        public async Task<IEnumerable<SuprimentoMovimentacaoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<SuprimentoMovimentacaoViewModel>>(await _suprimentoMovimentacaoRepository.ObterMovimentacoesSuprimentos());
        }

        [ClaimsAuthorize("Suprimento", "Adicionar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SuprimentoMovimentacaoViewModel>> ObterSuprimentoMovimentacaoPorId(Guid id)
        {
            var suprimentoMovimentacaoMovimentacao = _mapper.Map<SuprimentoMovimentacaoViewModel>(await _suprimentoMovimentacaoRepository.ObterSuprimentoMovimentacao(id));

            if (suprimentoMovimentacaoMovimentacao == null) return NotFound();

            return suprimentoMovimentacaoMovimentacao;
        }

        private async Task<SuprimentoMovimentacaoViewModel> ObterSuprimentoMovimentacao(Guid id)
        {
            return _mapper.Map<SuprimentoMovimentacaoViewModel>(await _suprimentoMovimentacaoRepository.ObterPorId(id));
        }
        #endregion
    }
}
