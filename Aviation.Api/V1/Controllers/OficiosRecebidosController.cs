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
using System.IO;

namespace AviationManagementApi.App.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/oficios-recebidos")]
    public class OficiosRecebidosController : MainController
    {
        private readonly IOficioRecebidoRepository _oficioRecebidoRepository;
        private readonly IOficioRecebidoServices _oficioRecebidoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public OficiosRecebidosController(IOficioRecebidoRepository oficioRecebidoRepository,
                                  IMapper mapper,
                                  IOficioRecebidoServices oficioRecebidoService,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _oficioRecebidoRepository = oficioRecebidoRepository;
            _mapper = mapper;
            _oficioRecebidoService = oficioRecebidoService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Oficio", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<OficioRecebidoViewModel>> Adicionar(OficioRecebidoViewModel oficioRecebidoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (oficioRecebidoViewModel.Arquivo != "" && oficioRecebidoViewModel.Arquivo != null)
            {
                var arquivoNome = Guid.NewGuid() + "_" + oficioRecebidoViewModel.Arquivo;
                if (!UploadArquivo(oficioRecebidoViewModel.ArquivoUpload, arquivoNome))
                {
                    return CustomResponse(oficioRecebidoViewModel);
                }

                oficioRecebidoViewModel.Arquivo = arquivoNome;
            }

            await _oficioRecebidoService.Adicionar(_mapper.Map<OficioRecebido>(oficioRecebidoViewModel));

            return CustomResponse(oficioRecebidoViewModel);
        }

        [ClaimsAuthorize("Oficio", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<OficioRecebidoViewModel>> Atualizar(Guid id, OficioRecebidoViewModel oficioRecebidoViewModel)
        {
            if (id != oficioRecebidoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var oficioRecebidoAtualizacao = await ObterOficioRecebido(id);

            if (string.IsNullOrEmpty(oficioRecebidoViewModel.Arquivo))
                oficioRecebidoViewModel.Arquivo = oficioRecebidoAtualizacao.Arquivo;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (oficioRecebidoViewModel.ArquivoUpload != null)
            {
                var arquivoNome = Guid.NewGuid() + "_" + oficioRecebidoViewModel.Arquivo;
                if (!UploadArquivo(oficioRecebidoViewModel.ArquivoUpload, arquivoNome))
                {
                    return CustomResponse(ModelState);
                }

                oficioRecebidoAtualizacao.Arquivo = arquivoNome;
            }

            oficioRecebidoAtualizacao.Data = oficioRecebidoViewModel.Data;
            oficioRecebidoAtualizacao.Numeracao = oficioRecebidoViewModel.Numeracao;
            oficioRecebidoAtualizacao.Assunto = oficioRecebidoViewModel.Assunto;
            oficioRecebidoAtualizacao.Remetente = oficioRecebidoViewModel.Remetente;

            await _oficioRecebidoService.Atualizar(_mapper.Map<OficioRecebido>(oficioRecebidoAtualizacao));

            return CustomResponse(oficioRecebidoViewModel);
        }

        [ClaimsAuthorize("Oficio", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<OficioRecebidoViewModel>> Excluir(Guid id)
        {
            var oficioRecebido = await ObterOficioRecebido(id);

            if (oficioRecebido == null)
            {
                NotificarErro("O id do ofício não foi encontrado.");
                return CustomResponse(oficioRecebido);
            }

            await _oficioRecebidoService.Remover(id);

            return CustomResponse(oficioRecebido);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Oficio", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<OficioRecebidoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<OficioRecebidoViewModel>>(await _oficioRecebidoRepository.ObterTodos());
        }

        [ClaimsAuthorize("Oficio", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OficioRecebidoViewModel>> ObterOficioRecebidoPorId(Guid id)
        {
            var oficioRecebido = _mapper.Map<OficioRecebidoViewModel>(await _oficioRecebidoRepository.ObterPorId(id));

            if (oficioRecebido == null) return NotFound();

            return oficioRecebido;
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

        private async Task<OficioRecebidoViewModel> ObterOficioRecebido(Guid id)
        {
            return _mapper.Map<OficioRecebidoViewModel>(await _oficioRecebidoRepository.ObterPorId(id));
        }
        #endregion
    }
}
