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
    [Route("api/v{version:apiVersion}/oficios-emitidos")]
    public class OficiosEmitidosController : MainController
    {
        private readonly IOficioEmitidoRepository _oficioEmitidoRepository;
        private readonly IOficioEmitidoServices _oficioEmitidoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public OficiosEmitidosController(IOficioEmitidoRepository oficioEmitidoRepository,
                                  IMapper mapper,
                                  IOficioEmitidoServices oficioEmitidoService,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _oficioEmitidoRepository = oficioEmitidoRepository;
            _mapper = mapper;
            _oficioEmitidoService = oficioEmitidoService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Oficio", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<OficioEmitidoViewModel>> Adicionar(OficioEmitidoViewModel oficioEmitidoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (oficioEmitidoViewModel.Arquivo != "" && oficioEmitidoViewModel.Arquivo != null)
            {
                var arquivoNome = Guid.NewGuid() + "_" + oficioEmitidoViewModel.Arquivo;
                if (!UploadArquivo(oficioEmitidoViewModel.ArquivoUpload, arquivoNome))
                {
                    return CustomResponse(oficioEmitidoViewModel);
                }

                oficioEmitidoViewModel.Arquivo = arquivoNome;
            }

            await _oficioEmitidoService.Adicionar(_mapper.Map<OficioEmitido>(oficioEmitidoViewModel));

            return CustomResponse(oficioEmitidoViewModel);
        }

        [ClaimsAuthorize("Oficio", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<OficioEmitidoViewModel>> Atualizar(Guid id, OficioEmitidoViewModel oficioEmitidoViewModel)
        {
            if (id != oficioEmitidoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var oficioEmitidoAtualizacao = await ObterOficioEmitido(id);

            if (string.IsNullOrEmpty(oficioEmitidoViewModel.Arquivo))
                oficioEmitidoViewModel.Arquivo = oficioEmitidoAtualizacao.Arquivo;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (oficioEmitidoViewModel.ArquivoUpload != null)
            {
                var arquivoNome = Guid.NewGuid() + "_" + oficioEmitidoViewModel.Arquivo;
                if (!UploadArquivo(oficioEmitidoViewModel.ArquivoUpload, arquivoNome))
                {
                    return CustomResponse(ModelState);
                }

                oficioEmitidoAtualizacao.Arquivo = arquivoNome;
            }
    
            oficioEmitidoAtualizacao.Data = oficioEmitidoViewModel.Data;
            oficioEmitidoAtualizacao.Numeracao = oficioEmitidoViewModel.Numeracao;
            oficioEmitidoAtualizacao.Mensagem = oficioEmitidoViewModel.Mensagem;
            oficioEmitidoAtualizacao.Responsavel = oficioEmitidoViewModel.Responsavel;
            oficioEmitidoAtualizacao.Destinatario = oficioEmitidoViewModel.Destinatario;
            oficioEmitidoAtualizacao.Assunto = oficioEmitidoViewModel.Assunto;

            await _oficioEmitidoService.Atualizar(_mapper.Map<OficioEmitido>(oficioEmitidoAtualizacao));

            return CustomResponse(oficioEmitidoViewModel);
        }

        [ClaimsAuthorize("Oficio", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<OficioEmitidoViewModel>> Excluir(Guid id)
        {
            var oficio = await ObterOficioEmitido(id);

            if (oficio == null)
            {
                NotificarErro("O id do ofício não foi encontrado.");
                return CustomResponse(oficio);
            }

            await _oficioEmitidoService.Remover(id);

            return CustomResponse(oficio);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Oficio", "Consultar")]
        [HttpGet]
        public async Task<PagedResult<OficioEmitidoViewModel>> ObterTodos([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null) 
        {
            return _mapper.Map<PagedResult<OficioEmitidoViewModel>>(await _oficioEmitidoRepository.ObterTodos(ps,page,q));
        }

        [ClaimsAuthorize("Oficio", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OficioEmitidoViewModel>> ObterOficioEmitidoPorId(Guid id)
        {
            var oficioEmitido = _mapper.Map<OficioEmitidoViewModel>(await _oficioEmitidoRepository.ObterPorId(id));

            if (oficioEmitido == null) return NotFound();

            return oficioEmitido;
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

        private async Task<OficioEmitidoViewModel> ObterOficioEmitido(Guid id)
        {
            return _mapper.Map<OficioEmitidoViewModel>(await _oficioEmitidoRepository.ObterPorId(id));
        }
        #endregion
    }
}