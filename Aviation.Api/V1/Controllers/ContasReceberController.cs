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
    [Route("api/v{version:apiVersion}/contas-receber")]
    public class ContasReceberController : MainController
    {
        private readonly IContasReceberRepository _contasReceberRepository;
        private readonly IContasReceberServices _contasReceberService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public ContasReceberController(INotificador notificador,
                                  IContasReceberRepository contasReceberRepository,
                                  IContasReceberServices contasReceberService,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _contasReceberRepository = contasReceberRepository;
            _contasReceberService = contasReceberService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Financeiro", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ContasReceberViewModel>> Adicionar(ContasReceberViewModel contasReceberViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _contasReceberService.Adicionar(_mapper.Map<ContasReceber>(contasReceberViewModel));

            return CustomResponse(contasReceberViewModel);
        }

        [ClaimsAuthorize("Financeiro", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ContasReceberViewModel contasReceberViewModel)
        {
            if (id != contasReceberViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var contasReceberAtualizacao = await ObterContaReceber(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            contasReceberAtualizacao.DataVencimento = contasReceberViewModel.DataVencimento;
            contasReceberAtualizacao.Descricao = contasReceberViewModel.Descricao;
            contasReceberAtualizacao.CodigoBarras = contasReceberViewModel.CodigoBarras;
            contasReceberAtualizacao.Situacao = contasReceberViewModel.Situacao;
            contasReceberAtualizacao.FormaPagamento = contasReceberViewModel.FormaPagamento;
            contasReceberAtualizacao.ValorReceber = contasReceberViewModel.ValorReceber;
            contasReceberAtualizacao.ValorRecebido = contasReceberViewModel.ValorRecebido;
            contasReceberAtualizacao.DataRecebimento = contasReceberViewModel.DataRecebimento;

            await _contasReceberService.Atualizar(_mapper.Map<ContasReceber>(contasReceberAtualizacao));

            return CustomResponse(contasReceberViewModel);
        }

        [ClaimsAuthorize("Financeiro", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ContasReceberViewModel>> Excluir(Guid id)
        {
            var contasReceber = await ObterContaReceber(id);

            if (contasReceber == null) return NotFound();

            await _contasReceberService.Remover(id);

            return CustomResponse(contasReceber);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Financeiro", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<ContasReceberViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ContasReceberViewModel>>(await _contasReceberRepository.ObterTodos());
        }

        [ClaimsAuthorize("Financeiro", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContasReceberViewModel>> ObterPorId(Guid id)
        {
            var contasReceberViewModel = await ObterContaReceber(id);

            if (contasReceberViewModel == null) return NotFound();

            return contasReceberViewModel;
        }

        private async Task<ContasReceberViewModel> ObterContaReceber(Guid id)
        {
            return _mapper.Map<ContasReceberViewModel>(await _contasReceberRepository.ObterPorId(id));
        }
        #endregion
    }
}