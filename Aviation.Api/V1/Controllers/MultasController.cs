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
    [Route("api/v{version:apiVersion}/veiculos/multas")]
    public class MultasController : MainController
    {
        private readonly IVeiculoMultaRepository _multaRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IVeiculoMultaServices _multaService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public MultasController(IVeiculoMultaRepository multaRepository,
                                IVeiculoRepository veiculoRepository,
                                IMapper mapper,
                                IVeiculoMultaServices multaService,
                                INotificador notificador, IUser user) : base(notificador, user)
        {
            _multaRepository = multaRepository;
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
            _multaService = multaService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Veiculo", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<VeiculoMultaViewModel>> Adicionar(VeiculoMultaViewModel veiculoMultaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            // Implementar upload de arquivo de multa

            await _multaService.Adicionar(_mapper.Map<VeiculoMulta>(veiculoMultaViewModel));

            return CustomResponse(veiculoMultaViewModel);
        }

        [ClaimsAuthorize("Veiculo", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<VeiculoMultaViewModel>> Atualizar(Guid id, VeiculoMultaViewModel veiculoMultaViewModel)
        {
            if (id != veiculoMultaViewModel.Id)
            {
                NotificarErro("O id informado é diferente do id da requisição.");
                return CustomResponse();
            }

            var veiculoMultaAtualizacao = await ObterVeiculoMulta(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            veiculoMultaAtualizacao.Data = veiculoMultaViewModel.Data;
            veiculoMultaAtualizacao.AutoInfracao = veiculoMultaViewModel.AutoInfracao;
            veiculoMultaAtualizacao.Responsavel = veiculoMultaViewModel.Responsavel;
            veiculoMultaAtualizacao.Classificacao = veiculoMultaViewModel.Classificacao;
            veiculoMultaAtualizacao.Descricao = veiculoMultaViewModel.Descricao;
            veiculoMultaAtualizacao.Situacao = veiculoMultaViewModel.Situacao;
            veiculoMultaAtualizacao.Valor = veiculoMultaViewModel.Valor;

            await _multaService.Atualizar(_mapper.Map<VeiculoMulta>(veiculoMultaAtualizacao));

            return CustomResponse(veiculoMultaViewModel);
        }

        [ClaimsAuthorize("Veiculo", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<VeiculoMultaViewModel>> Excluir(Guid id)
        {
            var veiculoMulta = await ObterVeiculoMulta(id);

            if (veiculoMulta == null)
            {
                NotificarErro("O id da multa não foi encontrado.");
                return CustomResponse(veiculoMulta);
            }

            await _multaService.Remover(id);

            return CustomResponse(veiculoMulta);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Veiculo", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<VeiculoMultaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<VeiculoMultaViewModel>>(await _multaRepository.ObterTodos());
        }

        [ClaimsAuthorize("Veiculo", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VeiculoMultaViewModel>> ObterVeiculoMultaPorId(Guid id)
        {
            var veiculoMulta = _mapper.Map<VeiculoMultaViewModel>(await _multaRepository.ObterPorId(id));

            if (veiculoMulta == null) return NotFound();

            return veiculoMulta;
        }

        private async Task<VeiculoMultaViewModel> ObterVeiculoMulta(Guid id)
        {
            return _mapper.Map<VeiculoMultaViewModel>(await _multaRepository.ObterPorId(id));
        }
        #endregion
    }
}