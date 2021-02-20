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
    [Route("api/v{version:apiVersion}/ordem-servico")]
    public class OrdensServicoController : MainController
    {
        private readonly IOrdemServicoRepository _ordemServicoRepository;
        private readonly IOrdemServicoServices _ordemServicoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public OrdensServicoController(IOrdemServicoRepository ordemServicoRepository,
                                  IMapper mapper,
                                  IOrdemServicoServices ordemServicoService,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _ordemServicoRepository = ordemServicoRepository;
            _mapper = mapper;
            _ordemServicoService = ordemServicoService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("OrdemServico", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<OrdemServicoViewModel>> Adicionar(OrdemServicoViewModel ordemServicoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _ordemServicoService.Adicionar(_mapper.Map<OrdemServico>(ordemServicoViewModel));

            return CustomResponse(ordemServicoViewModel);
        }

        [ClaimsAuthorize("OrdemServico", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<OrdemServicoViewModel>> Atualizar(Guid id, OrdemServicoViewModel ordemServicoViewModel)
        {
            if (id != ordemServicoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var ordemServicooAtualizacao = await ObterOrdemServico(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            ordemServicooAtualizacao.NumeroOrdem = ordemServicoViewModel.NumeroOrdem;
            ordemServicooAtualizacao.Tipo = ordemServicoViewModel.Tipo;
            ordemServicooAtualizacao.Ttsn = ordemServicoViewModel.Ttsn;
            ordemServicooAtualizacao.TcsnPousos = ordemServicoViewModel.TcsnPousos;
            ordemServicooAtualizacao.DataAbertura = ordemServicoViewModel.DataAbertura;
            ordemServicooAtualizacao.TtsnMotor = ordemServicoViewModel.TtsnMotor;
            ordemServicooAtualizacao.TcsnCiclos = ordemServicoViewModel.TcsnCiclos;
            ordemServicooAtualizacao.DataFechamento = ordemServicoViewModel.DataFechamento;
            ordemServicooAtualizacao.RequisicaoMateriais = ordemServicoViewModel.RequisicaoMateriais;
            ordemServicooAtualizacao.RealizadoPor = ordemServicoViewModel.RealizadoPor;
            ordemServicooAtualizacao.RealizadoPorAnac = ordemServicoViewModel.RealizadoPorAnac;
            ordemServicooAtualizacao.DataRealizacao = ordemServicoViewModel.DataRealizacao;
            ordemServicooAtualizacao.InspecionadoPor = ordemServicoViewModel.InspecionadoPor;
            ordemServicooAtualizacao.InspecionadoPorAnac = ordemServicoViewModel.InspecionadoPorAnac;
            ordemServicooAtualizacao.DataInspecao = ordemServicoViewModel.DataInspecao;

            await _ordemServicoService.Atualizar(_mapper.Map<OrdemServico>(ordemServicooAtualizacao));

            return CustomResponse(ordemServicoViewModel);
        }

        [ClaimsAuthorize("OrdemServico", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<OrdemServicoViewModel>> Excluir(Guid id)
        {
            var ordemServico = await ObterOrdemServico(id);

            if (ordemServico == null)
            {
                NotificarErro("O id da ordemnão foi encontrado.");
                return CustomResponse(ordemServico);
            }

            await _ordemServicoService.Remover(id);

            return CustomResponse(ordemServico);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("OrdemServico", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<OrdemServicoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<OrdemServicoViewModel>>(await _ordemServicoRepository.ObterTodos());
        }

        [AllowAnonymous]
        [HttpGet("quantidade")]
        public async Task<int> ObterQuantidadeOrdensAbertas()
        {
            return _mapper.Map<int>(await _ordemServicoRepository.ObterTotalRegistros());
        }

        [ClaimsAuthorize("OrdemServico", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrdemServicoViewModel>> ObterOrdemServicoPorId(Guid id)
        {
            var ordemServico = _mapper.Map<OrdemServicoViewModel>(await _ordemServicoRepository.ObterPorId(id));

            if (ordemServico == null) return NotFound();

            return ordemServico;
        }

        private async Task<OrdemServicoViewModel> ObterOrdemServico(Guid id)
        {
            return _mapper.Map<OrdemServicoViewModel>(await _ordemServicoRepository.ObterPorId(id));
        }
        #endregion
    }
}
