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
    [Route("api/v{version:apiVersion}/aeronaves/abastecimentos")]
    public class AbastecimentosController : MainController
    {
        private readonly IAeronaveAbastecimentoRepository _abastecimentoRepository;
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly IAeronaveAbastecimentoServices _abastecimentoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public AbastecimentosController(IAeronaveAbastecimentoRepository abastecimentoRepository,
                                  IAeronaveRepository aeronaveRepository,
                                  IMapper mapper,
                                  IAeronaveAbastecimentoServices abastecimentoService,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _abastecimentoRepository = abastecimentoRepository;
            _aeronaveRepository = aeronaveRepository;
            _mapper = mapper;
            _abastecimentoService = abastecimentoService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Abastecimento", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<AeronaveAbastecimentoViewModel>> Adicionar(AeronaveAbastecimentoViewModel aeronaveAbastecimentoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (aeronaveAbastecimentoViewModel.Comprovante != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + aeronaveAbastecimentoViewModel.Comprovante;
                if (!UploadArquivo(aeronaveAbastecimentoViewModel.ComprovanteUpload, imagemNome))
                {
                    return CustomResponse(aeronaveAbastecimentoViewModel);
                }

                aeronaveAbastecimentoViewModel.Comprovante = imagemNome;
            }
            else
            {
                aeronaveAbastecimentoViewModel.Comprovante = "NoImage.jpg";
            }

            await _abastecimentoService.Adicionar(_mapper.Map<AeronaveAbastecimento>(aeronaveAbastecimentoViewModel));

            return CustomResponse(aeronaveAbastecimentoViewModel);
        }

        [ClaimsAuthorize("Abastecimento", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AeronaveAbastecimentoViewModel>> Atualizar(Guid id, AeronaveAbastecimentoViewModel aeronaveAbastecimentoViewModel)
        {
            if (id != aeronaveAbastecimentoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var aeronaveAbastecimentoAtualizacao = await ObterAeronaveAbastecimento(id);

            if (string.IsNullOrEmpty(aeronaveAbastecimentoViewModel.Comprovante))
                aeronaveAbastecimentoViewModel.Comprovante = aeronaveAbastecimentoAtualizacao.Comprovante;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (aeronaveAbastecimentoViewModel.ComprovanteUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + aeronaveAbastecimentoViewModel.Comprovante;
                if (!UploadArquivo(aeronaveAbastecimentoViewModel.ComprovanteUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                aeronaveAbastecimentoAtualizacao.Comprovante = imagemNome;
            }

            aeronaveAbastecimentoAtualizacao.Data = aeronaveAbastecimentoViewModel.Data;
            aeronaveAbastecimentoAtualizacao.Litros = aeronaveAbastecimentoViewModel.Litros;
            aeronaveAbastecimentoAtualizacao.Local = aeronaveAbastecimentoViewModel.Local;
            aeronaveAbastecimentoAtualizacao.Cupom = aeronaveAbastecimentoViewModel.Cupom;
            aeronaveAbastecimentoAtualizacao.NotaFiscal = aeronaveAbastecimentoViewModel.NotaFiscal;
            aeronaveAbastecimentoAtualizacao.Fornecedora = aeronaveAbastecimentoViewModel.Fornecedora;
            aeronaveAbastecimentoAtualizacao.Responsavel = aeronaveAbastecimentoViewModel.Responsavel;
            aeronaveAbastecimentoAtualizacao.Valor = aeronaveAbastecimentoViewModel.Valor;
            aeronaveAbastecimentoAtualizacao.Observacoes = aeronaveAbastecimentoViewModel.Observacoes;

            await _abastecimentoService.Atualizar(_mapper.Map<AeronaveAbastecimento>(aeronaveAbastecimentoAtualizacao));

            return CustomResponse(aeronaveAbastecimentoViewModel);
        }

        [ClaimsAuthorize("Abastecimento", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AeronaveAbastecimentoViewModel>> Excluir(Guid id)
        {
            var abastecimentoAeronave = await ObterAeronaveAbastecimento(id);

            if (abastecimentoAeronave == null)
            {
                NotificarErro("O id do abastecimento não foi encontrado.");
                return CustomResponse(abastecimentoAeronave);
            }

            await _abastecimentoService.Remover(id);

            return CustomResponse(abastecimentoAeronave);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Abastecimento", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<AeronaveAbastecimentoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AeronaveAbastecimentoViewModel>>(await _abastecimentoRepository.ObterAbastecimentosAeronaves());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AeronaveAbastecimentoViewModel>> ObterAbastecimentoPorId(Guid id)
        {
            var abastecimento = _mapper.Map<AeronaveAbastecimentoViewModel>(await _abastecimentoRepository.ObterPorId(id));

            if (abastecimento == null) return NotFound();

            return abastecimento;
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este produto!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }

        private async Task<AeronaveAbastecimentoViewModel> ObterAeronaveAbastecimento(Guid id)
        {
            return _mapper.Map<AeronaveAbastecimentoViewModel>(await _abastecimentoRepository.ObterPorId(id));
        }
        #endregion
    }
}
