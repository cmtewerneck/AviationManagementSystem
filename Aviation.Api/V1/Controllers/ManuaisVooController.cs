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
    [Route("api/v{version:apiVersion}/manuais-voo")]
    public class ManuaisVooController : MainController
    {
        private readonly IManualVooRepository _manualVooRepository;
        private readonly IManualVooServices _manualVooService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public ManuaisVooController(INotificador notificador,
                                  IManualVooRepository manualVooRepository,
                                  IManualVooServices manualVooService, 
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _manualVooRepository = manualVooRepository;
            _manualVooService = manualVooService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Manual", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ManualVooViewModel>> Adicionar(ManualVooViewModel manualVooViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (manualVooViewModel.Arquivo != "" && manualVooViewModel.Arquivo != null)
            {
                var arquivoNome = Guid.NewGuid() + "_" + manualVooViewModel.Arquivo;
                if (!UploadArquivo(manualVooViewModel.ArquivoUpload, arquivoNome))
                {
                    return CustomResponse(manualVooViewModel);
                }

                manualVooViewModel.Arquivo = arquivoNome;
            }

            await _manualVooService.Adicionar(_mapper.Map<ManualVoo>(manualVooViewModel));

            return CustomResponse(manualVooViewModel);
        }

        [ClaimsAuthorize("Manual", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ManualVooViewModel manualVooViewModel)
        {
            if (id != manualVooViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var manualVooAtualizacao = await ObterManualVoo(id);

            if (string.IsNullOrEmpty(manualVooViewModel.Arquivo))
                manualVooViewModel.Arquivo = manualVooAtualizacao.Arquivo;
            
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (manualVooViewModel.ArquivoUpload != null)
            {
                var arquivoNome = Guid.NewGuid() + "_" + manualVooViewModel.Arquivo;
                if (!UploadArquivo(manualVooViewModel.ArquivoUpload, arquivoNome))
                {
                    return CustomResponse(ModelState);
                }

                manualVooAtualizacao.Arquivo = arquivoNome;
            }

            manualVooAtualizacao.ModeloAeronave = manualVooViewModel.ModeloAeronave;
            manualVooAtualizacao.UltimaRevisao = manualVooViewModel.UltimaRevisao;
            
            await _manualVooService.Atualizar(_mapper.Map<ManualVoo>(manualVooAtualizacao));

            return CustomResponse(manualVooViewModel);
        }

        [ClaimsAuthorize("Manual", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ManualVooViewModel>> Excluir(Guid id)
        {
            var manualVoo = await ObterManualVoo(id);

            if (manualVoo == null) return NotFound();

            await _manualVooService.Remover(id);

            return CustomResponse(manualVoo);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Manual", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<ManualVooViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ManualVooViewModel>>(await _manualVooRepository.ObterTodos());
        }

        [ClaimsAuthorize("Manual", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ManualVooViewModel>> ObterPorId(Guid id)
        {
            var manualVooViewModel = await ObterManualVoo(id);

            if (manualVooViewModel == null) return NotFound();

            return manualVooViewModel;
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

        private async Task<ManualVooViewModel> ObterManualVoo(Guid id)
        {
            return _mapper.Map<ManualVooViewModel>(await _manualVooRepository.ObterPorId(id));
        }
        #endregion
    }
}