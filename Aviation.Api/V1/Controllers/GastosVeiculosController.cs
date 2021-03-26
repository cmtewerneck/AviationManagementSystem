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
    [Route("api/v{version:apiVersion}/veiculos/gastos")]
    public class GastosVeiculosController : MainController
    {
        private readonly IVeiculoGastoRepository _gastosVeiculoRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IVeiculoGastoServices _gastosVeiculoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public GastosVeiculosController(IVeiculoGastoRepository gastosVeiculoRepository,
                                  IVeiculoRepository veiculoRepository,
                                  IMapper mapper,
                                  IVeiculoGastoServices gastosVeiculoService,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _gastosVeiculoRepository = gastosVeiculoRepository;
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
            _gastosVeiculoService = gastosVeiculoService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Veiculo", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<VeiculoGastoViewModel>> Adicionar(VeiculoGastoViewModel veiculoGastoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            // Implementar upload de comprovante de gasto

            await _gastosVeiculoService.Adicionar(_mapper.Map<VeiculoGasto>(veiculoGastoViewModel));

            return CustomResponse(veiculoGastoViewModel);
        }

        [ClaimsAuthorize("Veiculo", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<VeiculoGastoViewModel>> Atualizar(Guid id, VeiculoGastoViewModel veiculoGastoViewModel)
        {
            if (id != veiculoGastoViewModel.Id)
            {
                NotificarErro("O id informado é diferente do id da requisição.");
                return CustomResponse();
            }

            var veiculoGastoAtualizacao = await ObterVeiculoGasto(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            veiculoGastoAtualizacao.Data = veiculoGastoViewModel.Data;
            veiculoGastoAtualizacao.Descricao = veiculoGastoViewModel.Descricao;
            veiculoGastoAtualizacao.Situacao = veiculoGastoViewModel.Situacao;
            veiculoGastoAtualizacao.Valor = veiculoGastoViewModel.Valor;

            await _gastosVeiculoService.Atualizar(_mapper.Map<VeiculoGasto>(veiculoGastoAtualizacao));

            return CustomResponse(veiculoGastoViewModel);
        }

        [ClaimsAuthorize("Veiculo", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<VeiculoGastoViewModel>> Excluir(Guid id)
        {
            var veiculoGasto = await ObterVeiculoGasto(id);

            if (veiculoGasto == null)
            {
                NotificarErro("O id da multa não foi encontrado.");
                return CustomResponse(veiculoGasto);
            }

            await _gastosVeiculoService.Remover(id);

            return CustomResponse(veiculoGasto);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Veiculo", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<VeiculoGastoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<VeiculoGastoViewModel>>(await _gastosVeiculoRepository.ObterGastosVeiculos());
        }

        [ClaimsAuthorize("Veiculo", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VeiculoGastoViewModel>> ObterVeiculoGastoPorId(Guid id)
        {
            var veiculoGasto = _mapper.Map<VeiculoGastoViewModel>(await _gastosVeiculoRepository.ObterGastoVeiculo(id));

            if (veiculoGasto == null) return NotFound();

            return veiculoGasto;
        }

        private async Task<VeiculoGastoViewModel> ObterVeiculoGasto(Guid id)
        {
            return _mapper.Map<VeiculoGastoViewModel>(await _gastosVeiculoRepository.ObterPorId(id));
        }
        #endregion
    }
}
