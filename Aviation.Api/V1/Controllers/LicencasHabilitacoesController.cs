using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using AviationManagementApi.Api.Controllers;
using AviationManagementApi.Api.Extensions;
using AviationManagementApi.Api.ViewModels;
using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AviationManagementApi.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/licencas-habilitacoes")]
    public class LicencaHabilitacaoController : MainController
    {
        private readonly ILicencaHabilitacaoRepository _licencaHabilitacaoRepository;
        private readonly ILicencaHabilitacaoServices _licencaHabilitacaoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public LicencaHabilitacaoController(INotificador notificador,
                                  ILicencaHabilitacaoRepository licencaHabilitacaoRepository,
                                  ILicencaHabilitacaoServices licencaHabilitacaoService,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _licencaHabilitacaoRepository = licencaHabilitacaoRepository;
            _licencaHabilitacaoService = licencaHabilitacaoService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("LicencaHabilitacao", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<LicencaHabilitacaoViewModel>> Adicionar(LicencaHabilitacaoViewModel licencaHabilitacaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _licencaHabilitacaoService.Adicionar(_mapper.Map<LicencaHabilitacao>(licencaHabilitacaoViewModel));

            return CustomResponse(licencaHabilitacaoViewModel);
        }

        [ClaimsAuthorize("LicencaHabilitacao", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, LicencaHabilitacaoViewModel licencaHabilitacaoViewModel)
        {
            if (id != licencaHabilitacaoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var licencaHabilitacaoAtualizacao = await ObterLicencaHabilitacao(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            licencaHabilitacaoAtualizacao.Titulo = licencaHabilitacaoViewModel.Titulo;
            licencaHabilitacaoAtualizacao.Validade = licencaHabilitacaoViewModel.Validade;
            licencaHabilitacaoAtualizacao.ColaboradorId = licencaHabilitacaoViewModel.ColaboradorId;

            await _licencaHabilitacaoService.Atualizar(_mapper.Map<LicencaHabilitacao>(licencaHabilitacaoAtualizacao));

            return CustomResponse(licencaHabilitacaoViewModel);
        }

        [ClaimsAuthorize("LicencaHabilitacao", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<LicencaHabilitacaoViewModel>> Excluir(Guid id)
        {
            var licencaHabilitacao = await ObterLicencaHabilitacao(id);

            if (licencaHabilitacao == null) return NotFound();

            await _licencaHabilitacaoService.Remover(id);

            return CustomResponse(licencaHabilitacao);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("LicencaHabilitacao", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<LicencaHabilitacaoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<LicencaHabilitacaoViewModel>>(await _licencaHabilitacaoRepository.ObterLicencasColaboradores());
        }

        [ClaimsAuthorize("LicencaHabilitacao", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LicencaHabilitacaoViewModel>> ObterPorId(Guid id)
        {
            var licencaHabilitacaoViewModel = await ObterLicencaHabilitacao(id);

            if (licencaHabilitacaoViewModel == null) return NotFound();

            return licencaHabilitacaoViewModel;
        }

        private async Task<LicencaHabilitacaoViewModel> ObterLicencaHabilitacao(Guid id)
        {
            return _mapper.Map<LicencaHabilitacaoViewModel>(await _licencaHabilitacaoRepository.ObterLicencaColaborador(id));
        }
        #endregion
    }
}