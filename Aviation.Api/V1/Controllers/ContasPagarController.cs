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
    [Route("api/v{version:apiVersion}/contas-pagar")]
    public class ContasPagarController : MainController
    {
        private readonly IContasPagarRepository _contasPagarRepository;
        private readonly IContasPagarServices _contasPagarService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public ContasPagarController(INotificador notificador,
                                  IContasPagarRepository contasPagarRepository,
                                  IContasPagarServices contasPagarService,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _contasPagarRepository = contasPagarRepository;
            _contasPagarService = contasPagarService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Financeiro", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ContasPagarViewModel>> Adicionar(ContasPagarViewModel contasPagarViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _contasPagarService.Adicionar(_mapper.Map<ContasPagar>(contasPagarViewModel));

            return CustomResponse(contasPagarViewModel);
        }

        [ClaimsAuthorize("Financeiro", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ContasPagarViewModel contasPagarViewModel)
        {
            if (id != contasPagarViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var contasPagarAtualizacao = await ObterContaPagar(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            contasPagarAtualizacao.DataVencimento = contasPagarViewModel.DataVencimento;
            contasPagarAtualizacao.Descricao = contasPagarViewModel.Descricao;
            contasPagarAtualizacao.CodigoBarras = contasPagarViewModel.CodigoBarras;
            contasPagarAtualizacao.Situacao = contasPagarViewModel.Situacao;
            contasPagarAtualizacao.FormaPagamento = contasPagarViewModel.FormaPagamento;
            contasPagarAtualizacao.ValorPagar = contasPagarViewModel.ValorPagar;
            contasPagarAtualizacao.ValorPago = contasPagarViewModel.ValorPago;
            contasPagarAtualizacao.DataPagamento = contasPagarViewModel.DataPagamento;

            await _contasPagarService.Atualizar(_mapper.Map<ContasPagar>(contasPagarAtualizacao));

            return CustomResponse(contasPagarViewModel);
        }

        [ClaimsAuthorize("Financeiro", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ContasPagarViewModel>> Excluir(Guid id)
        {
            var contasPagar = await ObterContaPagar(id);

            if (contasPagar == null) return NotFound();

            await _contasPagarService.Remover(id);

            return CustomResponse(contasPagar);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Financeiro", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<ContasPagarViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ContasPagarViewModel>>(await _contasPagarRepository.ObterTodos());
        }

        [ClaimsAuthorize("Financeiro", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContasPagarViewModel>> ObterPorId(Guid id)
        {
            var contasPagarViewModel = await ObterContaPagar(id);

            if (contasPagarViewModel == null) return NotFound();

            return contasPagarViewModel;
        }

        private async Task<ContasPagarViewModel> ObterContaPagar(Guid id)
        {
            return _mapper.Map<ContasPagarViewModel>(await _contasPagarRepository.ObterPorId(id));
        }
        #endregion
    }
}