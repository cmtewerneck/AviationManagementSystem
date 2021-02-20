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
    [Route("api/v{version:apiVersion}/suprimentos")]
    public class SuprimentosController : MainController
    {
        private readonly ISuprimentoRepository _suprimentoRepository;
        private readonly ISuprimentoServices _suprimentoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public SuprimentosController(ISuprimentoRepository suprimentoRepository,
                                  IMapper mapper,
                                  ISuprimentoServices suprimentoService,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _suprimentoRepository = suprimentoRepository;
            _mapper = mapper;
            _suprimentoService = suprimentoService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Suprimento", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<SuprimentoViewModel>> Adicionar(SuprimentoViewModel suprimentoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (suprimentoViewModel.Imagem != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + suprimentoViewModel.Imagem;
                if (!UploadArquivo(suprimentoViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(suprimentoViewModel);
                }

                suprimentoViewModel.Imagem = imagemNome;
            }
            else
            {
                suprimentoViewModel.Imagem = "NoImage.jpg";
            }

            await _suprimentoService.Adicionar(_mapper.Map<Suprimento>(suprimentoViewModel));

            return CustomResponse(suprimentoViewModel);
        }

        [ClaimsAuthorize("Suprimento", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SuprimentoViewModel>> Atualizar(Guid id, SuprimentoViewModel suprimentoViewModel)
        {
            if (id != suprimentoViewModel.Id)
            {
                NotificarErro("O id informado é diferente do id da requisição.");
                return CustomResponse();
            }

            var suprimentoAtualizacao = await ObterSuprimento(id);

            if (string.IsNullOrEmpty(suprimentoViewModel.Imagem))
                suprimentoViewModel.Imagem = suprimentoAtualizacao.Imagem;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (suprimentoViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + suprimentoViewModel.Imagem;
                if (!UploadArquivo(suprimentoViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                suprimentoAtualizacao.Imagem = imagemNome;
            }

            suprimentoAtualizacao.Codigo = suprimentoViewModel.Codigo;
            suprimentoAtualizacao.PartNumber = suprimentoViewModel.PartNumber;
            suprimentoAtualizacao.Nomenclatura = suprimentoViewModel.Nomenclatura;
            suprimentoAtualizacao.Quantidade = suprimentoViewModel.Quantidade;
            suprimentoAtualizacao.Localizacao = suprimentoViewModel.Localizacao;
            suprimentoAtualizacao.PartNumberAlternativo = suprimentoViewModel.PartNumberAlternativo;
            suprimentoAtualizacao.Aplicacao = suprimentoViewModel.Aplicacao;
            suprimentoAtualizacao.Capitulo = suprimentoViewModel.Capitulo;
            suprimentoAtualizacao.SerialNumber = suprimentoViewModel.SerialNumber;
            suprimentoAtualizacao.Doc = suprimentoViewModel.Doc;

            await _suprimentoService.Atualizar(_mapper.Map<Suprimento>(suprimentoAtualizacao));

            return CustomResponse(suprimentoViewModel);
        }

        [ClaimsAuthorize("Suprimento", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SuprimentoViewModel>> Excluir(Guid id)
        {
            var suprimentoViewModel = await ObterSuprimento(id);

            if (suprimentoViewModel == null)
            {
                NotificarErro("O id do item não foi encontrado.");
                return CustomResponse(suprimentoViewModel);
            }

            await _suprimentoService.Remover(id);

            return CustomResponse(suprimentoViewModel);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Suprimento", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<SuprimentoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<SuprimentoViewModel>>(await _suprimentoRepository.ObterTodos());
        }

        [ClaimsAuthorize("Suprimento", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SuprimentoViewModel>> ObterMaterialPorId(Guid id)
        {
            var suprimento = _mapper.Map<SuprimentoViewModel>(await _suprimentoRepository.ObterPorId(id));

            if (suprimento == null) return NotFound();

            return suprimento;
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este item!");
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

        private async Task<SuprimentoViewModel> ObterSuprimento(Guid id)
        {
            return _mapper.Map<SuprimentoViewModel>(await _suprimentoRepository.ObterPorId(id));
        }
        #endregion
    }
}
