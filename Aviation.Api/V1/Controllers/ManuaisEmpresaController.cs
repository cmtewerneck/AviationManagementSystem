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
using System.IO;
using System.Threading.Tasks;

namespace AviationManagementApi.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/manuais-empresa")]
    public class ManuaisEmpresaController : MainController
    {
        private readonly IManualEmpresaRepository _manualEmpresaRepository;
        private readonly IManualEmpresaServices _manualEmpresaService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public ManuaisEmpresaController(INotificador notificador,
                                  IManualEmpresaRepository manualEmpresaRepository,
                                  IManualEmpresaServices manualEmpresaService,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _manualEmpresaRepository = manualEmpresaRepository;
            _manualEmpresaService = manualEmpresaService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Manual", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ManualEmpresaViewModel>> Adicionar(ManualEmpresaViewModel manualEmpresaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (manualEmpresaViewModel.Arquivo != "" && manualEmpresaViewModel.Arquivo != null)
            {
                var arquivoNome = Guid.NewGuid() + "_" + manualEmpresaViewModel.Arquivo;
                if (!UploadArquivo(manualEmpresaViewModel.ArquivoUpload, arquivoNome))
                {
                    return CustomResponse(manualEmpresaViewModel);
                }

                manualEmpresaViewModel.Arquivo = arquivoNome;
            }

            await _manualEmpresaService.Adicionar(_mapper.Map<ManualEmpresa>(manualEmpresaViewModel));

            return CustomResponse(manualEmpresaViewModel);
        }

        [ClaimsAuthorize("Manual", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ManualEmpresaViewModel manualEmpresaViewModel)
        {
            if (id != manualEmpresaViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var manualEmpresaAtualizacao = await ObterManualEmpresa(id);

            if (string.IsNullOrEmpty(manualEmpresaViewModel.Arquivo))
                manualEmpresaViewModel.Arquivo = manualEmpresaAtualizacao.Arquivo;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (manualEmpresaViewModel.ArquivoUpload != null)
            {
                var arquivoNome = Guid.NewGuid() + "_" + manualEmpresaViewModel.Arquivo;
                if (!UploadArquivo(manualEmpresaViewModel.ArquivoUpload, arquivoNome))
                {
                    return CustomResponse(ModelState);
                }

                manualEmpresaAtualizacao.Arquivo = arquivoNome;
            }

            manualEmpresaAtualizacao.Descricao = manualEmpresaViewModel.Descricao;
            manualEmpresaAtualizacao.Sigla = manualEmpresaViewModel.Sigla;
            manualEmpresaAtualizacao.RevisaoAtual = manualEmpresaViewModel.RevisaoAtual;
            manualEmpresaAtualizacao.DataRevisao = manualEmpresaViewModel.DataRevisao;
            manualEmpresaAtualizacao.RevisaoAnalise = manualEmpresaViewModel.RevisaoAnalise;

            await _manualEmpresaService.Atualizar(_mapper.Map<ManualEmpresa>(manualEmpresaAtualizacao));

            return CustomResponse(manualEmpresaViewModel);
        }

        [ClaimsAuthorize("Manual", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ManualEmpresaViewModel>> Excluir(Guid id)
        {
            var manualEmpresa = await ObterManualEmpresa(id);

            if (manualEmpresa == null) return NotFound();

            await _manualEmpresaService.Remover(id);

            return CustomResponse(manualEmpresa);
        }
        #endregion

        #region METHODS
        private bool UploadArquivo(string arquivo, string fileName)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça um arquivo para este ofício!");
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

        private async Task<ManualEmpresaViewModel> ObterManualEmpresa(Guid id)
        {
            return _mapper.Map<ManualEmpresaViewModel>(await _manualEmpresaRepository.ObterPorId(id));
        }

        [ClaimsAuthorize("Manual", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<ManualEmpresaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ManualEmpresaViewModel>>(await _manualEmpresaRepository.ObterTodos());
        }

        [ClaimsAuthorize("Manual", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ManualEmpresaViewModel>> ObterPorId(Guid id)
        {
            var manualEmpresaViewModel = await ObterManualEmpresa(id);

            if (manualEmpresaViewModel == null) return NotFound();

            return manualEmpresaViewModel;
        }
        #endregion
    }
}