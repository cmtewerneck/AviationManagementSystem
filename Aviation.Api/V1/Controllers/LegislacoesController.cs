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
    [Route("api/v{version:apiVersion}/legislacoes")]
    public class LegislacoesController : MainController
    {
        private readonly ILegislacaoRepository _legislacaoRepository;
        private readonly ILegislacaoServices _legislacaoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public LegislacoesController(INotificador notificador,
                                  ILegislacaoRepository legislacaoRepository,
                                  ILegislacaoServices legislacaoService,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _legislacaoRepository = legislacaoRepository;
            _legislacaoService = legislacaoService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Legislacao", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<LegislacaoViewModel>> Adicionar(LegislacaoViewModel legislacaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (legislacaoViewModel.Arquivo != "" && legislacaoViewModel.Arquivo != null)
            {
                var arquivoNome = Guid.NewGuid() + "_" + legislacaoViewModel.Arquivo;
                if (!UploadArquivo(legislacaoViewModel.ArquivoUpload, arquivoNome))
                {
                    return CustomResponse(legislacaoViewModel);
                }

                legislacaoViewModel.Arquivo = arquivoNome;
            }

            await _legislacaoService.Adicionar(_mapper.Map<Legislacao>(legislacaoViewModel));

            return CustomResponse(legislacaoViewModel);
        }

        [ClaimsAuthorize("Legislacao", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, LegislacaoViewModel legislacaoViewModel)
        {
            if (id != legislacaoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var legislacaoAtualizacao = await ObterLegislacao(id);

            if (string.IsNullOrEmpty(legislacaoViewModel.Arquivo))
                legislacaoViewModel.Arquivo = legislacaoAtualizacao.Arquivo;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (legislacaoViewModel.ArquivoUpload != null)
            {
                var arquivoNome = Guid.NewGuid() + "_" + legislacaoViewModel.Arquivo;
                if (!UploadArquivo(legislacaoViewModel.ArquivoUpload, arquivoNome))
                {
                    return CustomResponse(ModelState);
                }

                legislacaoAtualizacao.Arquivo = arquivoNome;
            }

            legislacaoAtualizacao.Titulo = legislacaoViewModel.Titulo;
            legislacaoAtualizacao.TipoLegislacao = legislacaoViewModel.TipoLegislacao;
            legislacaoAtualizacao.Numero = legislacaoViewModel.Numero;
            legislacaoAtualizacao.Emenda = legislacaoViewModel.Emenda;
            legislacaoAtualizacao.DataEmenda = legislacaoViewModel.DataEmenda;

            await _legislacaoService.Atualizar(_mapper.Map<Legislacao>(legislacaoAtualizacao));

            return CustomResponse(legislacaoViewModel);
        }

        [ClaimsAuthorize("Legislacao", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<LegislacaoViewModel>> Excluir(Guid id)
        {
            var legislacao = await ObterLegislacao(id);

            if (legislacao == null) return NotFound();

            await _legislacaoService.Remover(id);

            return CustomResponse(legislacao);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Legislacao", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<LegislacaoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<LegislacaoViewModel>>(await _legislacaoRepository.ObterTodos());
        }

        [ClaimsAuthorize("Legislacao", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LegislacaoViewModel>> ObterPorId(Guid id)
        {
            var legislacaoViewModel = await ObterLegislacao(id);

            if (legislacaoViewModel == null) return NotFound();

            return legislacaoViewModel;
        }

        private bool UploadArquivo(string arquivo, string fileName)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Envie um arquivo!");
                return false;
            }

            // var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);

            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            // System.IO.File.WriteAllBytes(filePath, arquivo);

            return true;
        }

        private async Task<LegislacaoViewModel> ObterLegislacao(Guid id)
        {
            return _mapper.Map<LegislacaoViewModel>(await _legislacaoRepository.ObterPorId(id));
        }
        #endregion
    }
}