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
    [Route("api/v{version:apiVersion}/servicos")]
    public class ServicosController : MainController
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IServicoServices _servicoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public ServicosController(IServicoRepository servicoRepository,
                                  IMapper mapper,
                                  IServicoServices servicoService,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _servicoRepository = servicoRepository;
            _mapper = mapper;
            _servicoService = servicoService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Servico", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ServicoViewModel>> Adicionar(ServicoViewModel servicoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _servicoService.Adicionar(_mapper.Map<Servico>(servicoViewModel));

            return CustomResponse(servicoViewModel);
        }

        [ClaimsAuthorize("Servico", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ServicoViewModel>> Atualizar(Guid id, ServicoViewModel servicoViewModel)
        {
            if (id != servicoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var servicoAtualizacao = await ObterServico(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            servicoAtualizacao.Codigo = servicoViewModel.Codigo;
            servicoAtualizacao.Titulo = servicoViewModel.Titulo;
            servicoAtualizacao.Custo = servicoViewModel.Custo;

            await _servicoService.Atualizar(_mapper.Map<Servico>(servicoAtualizacao));

            return CustomResponse(servicoViewModel);
        }

        [ClaimsAuthorize("Servico", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ServicoViewModel>> Excluir(Guid id)
        {
            var servico = await ObterServico(id);

            if (servico == null)
            {
                NotificarErro("O id do serviço não foi encontrado.");
                return CustomResponse(servico);
            }

            await _servicoService.Remover(id);

            return CustomResponse(servico);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Servico", "Adicionar")]
        [HttpGet]
        public async Task<IEnumerable<ServicoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ServicoViewModel>>(await _servicoRepository.ObterTodos());
        }

        [ClaimsAuthorize("Servico", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ServicoViewModel>> ObterServicoPorId(Guid id)
        {
            var servicoViewModel = await ObterServico(id);

            if (servicoViewModel == null) return NotFound();

            return servicoViewModel;
        }

        private async Task<ServicoViewModel> ObterServico(Guid id)
        {
            return _mapper.Map<ServicoViewModel>(await _servicoRepository.ObterPorId(id));
        }
        #endregion
    }
}