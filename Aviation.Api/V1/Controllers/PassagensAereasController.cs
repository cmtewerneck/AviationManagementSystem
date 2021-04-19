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
    [Route("api/v{version:apiVersion}/passagens-aereas")]
    public class PassagensAereasController : MainController
    {
        private readonly IPassagemAereaRepository _passagemAereaRepository;
        private readonly IPassagemAereaService _passagemAereaService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public PassagensAereasController(INotificador notificador,
                                  IPassagemAereaRepository passagemAereaRepository,
                                  IPassagemAereaService passagemAereaService,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _passagemAereaRepository = passagemAereaRepository;
            _passagemAereaService = passagemAereaService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Passagem", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<DiariaTripulanteViewModel>> Adicionar(PassagemAereaViewModel passagemAereaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _passagemAereaService.Adicionar(_mapper.Map<PassagemAerea>(passagemAereaViewModel));

            return CustomResponse(passagemAereaViewModel);
        }

        [ClaimsAuthorize("Passagem", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, PassagemAereaViewModel passagemAereaViewModel)
        {
            if (id != passagemAereaViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var passagemAereaAtualizacao = await ObterPassagemAerea(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            passagemAereaAtualizacao.DataCompra = passagemAereaViewModel.DataCompra;
            passagemAereaAtualizacao.DataVoo = passagemAereaViewModel.DataVoo;
            passagemAereaAtualizacao.Valor = passagemAereaViewModel.Valor;
            passagemAereaAtualizacao.Empresa = passagemAereaViewModel.Empresa;
            passagemAereaAtualizacao.Origem = passagemAereaViewModel.Origem;
            passagemAereaAtualizacao.Destino = passagemAereaViewModel.Destino;
            passagemAereaAtualizacao.FormaPagamento = passagemAereaViewModel.FormaPagamento;
            passagemAereaAtualizacao.Assento = passagemAereaViewModel.Assento;
            passagemAereaAtualizacao.Localizador = passagemAereaViewModel.Localizador;
            passagemAereaAtualizacao.ColaboradorId = passagemAereaViewModel.ColaboradorId;

            await _passagemAereaService.Atualizar(_mapper.Map<PassagemAerea>(passagemAereaAtualizacao));

            return CustomResponse(passagemAereaViewModel);
        }

        [ClaimsAuthorize("Passagem", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<PassagemAereaViewModel>> Excluir(Guid id)
        {
            var passagemAerea = await ObterPassagemAerea(id);

            if (passagemAerea == null) return NotFound();

            await _passagemAereaService.Remover(id);

            return CustomResponse(passagemAerea);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Passagem", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<PassagemAereaViewModel>> ObterTodos()
        {
            var entidade = await _passagemAereaRepository.ObterPassagensAereasColaborador();
            return _mapper.Map<IEnumerable<PassagemAereaViewModel>>(entidade);
        }

        [ClaimsAuthorize("Passagem", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PassagemAereaViewModel>> ObterPorId(Guid id)
        {
            var passagemAerea = await ObterPassagemAerea(id);

            if (passagemAerea == null) return NotFound();

            return passagemAerea;
        }

        private async Task<PassagemAereaViewModel> ObterPassagemAerea(Guid id)
        {
            return _mapper.Map<PassagemAereaViewModel>(await _passagemAereaRepository.ObterPassagemAereaColaborador(id));
        }
        #endregion
    }
}