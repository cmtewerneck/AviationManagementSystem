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
    [Route("api/v{version:apiVersion}/aeronaves/documentos")]
    public class AeronavesDocumentosController : MainController
    {
        private readonly IAeronaveDocumentoRepository _aeronaveDocumentoRepository;
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly IAeronaveDocumentoService _aeronaveDocumentoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public AeronavesDocumentosController(IAeronaveDocumentoRepository aeronaveDocumentoRepository,
                                  IAeronaveRepository aeronaveRepository,
                                  IMapper mapper,
                                  IAeronaveDocumentoService aeronaveDocumentoService,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _aeronaveDocumentoRepository = aeronaveDocumentoRepository;
            _aeronaveRepository = aeronaveRepository;
            _mapper = mapper;
            _aeronaveDocumentoService = aeronaveDocumentoService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Aeronave", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<AeronaveDocumentoViewModel>> Adicionar(AeronaveDocumentoViewModel aeronaveDocumentoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _aeronaveDocumentoService.Adicionar(_mapper.Map<AeronaveDocumento>(aeronaveDocumentoViewModel));

            return CustomResponse(aeronaveDocumentoViewModel);
        }

        [ClaimsAuthorize("Aeronave", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AeronaveDocumentoViewModel>> Atualizar(Guid id, AeronaveDocumentoViewModel aeronaveDocumentoViewModel)
        {
            if (id != aeronaveDocumentoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var aeronaveDocumentoAtualizacao = await ObterAeronaveDocumento(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            aeronaveDocumentoAtualizacao.Titulo = aeronaveDocumentoViewModel.Titulo;
            aeronaveDocumentoAtualizacao.DataValidade = aeronaveDocumentoViewModel.DataValidade;
            aeronaveDocumentoAtualizacao.DataEmissao = aeronaveDocumentoViewModel.DataEmissao;
            aeronaveDocumentoAtualizacao.AeronaveId = aeronaveDocumentoViewModel.AeronaveId;

            await _aeronaveDocumentoService.Atualizar(_mapper.Map<AeronaveDocumento>(aeronaveDocumentoAtualizacao));

            return CustomResponse(aeronaveDocumentoViewModel);
        }

        [ClaimsAuthorize("Aeronave", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AeronaveDocumentoViewModel>> Excluir(Guid id)
        {
            var aeronaveDocumentoAeronave = await ObterAeronaveDocumento(id);

            if (aeronaveDocumentoAeronave == null)
            {
                NotificarErro("O id do Documento não foi encontrado.");
                return CustomResponse(aeronaveDocumentoAeronave);
            }

            await _aeronaveDocumentoService.Remover(id);

            return CustomResponse(aeronaveDocumentoAeronave);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Aeronave", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<AeronaveDocumentoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AeronaveDocumentoViewModel>>(await _aeronaveDocumentoRepository.ObterDocumentosAeronaves());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AeronaveDocumentoViewModel>> ObterDocumentoPorId(Guid id)
        {
            var aeronaveDocumento = _mapper.Map<AeronaveDocumentoViewModel>(await _aeronaveDocumentoRepository.ObterDocumentoAeronave(id));

            if (aeronaveDocumento == null) return NotFound();

            return aeronaveDocumento;
        }

        private async Task<AeronaveDocumentoViewModel> ObterAeronaveDocumento(Guid id)
        {
            return _mapper.Map<AeronaveDocumentoViewModel>(await _aeronaveDocumentoRepository.ObterPorId(id));
        }
        #endregion
    }
}
