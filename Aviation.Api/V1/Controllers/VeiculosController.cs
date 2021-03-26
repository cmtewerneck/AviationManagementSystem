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
    [Route("api/v{version:apiVersion}/veiculos")]
    public class VeiculosController : MainController
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IVeiculoServices _veiculoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public VeiculosController(IVeiculoRepository veiculoRepository,
                                      IMapper mapper,
                                      IVeiculoServices veiculoService,
                                      INotificador notificador, IUser user) : base(notificador, user)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
            _veiculoService = veiculoService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Veiculo", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<VeiculoViewModel>> Adicionar(VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (veiculoViewModel.Imagem != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + veiculoViewModel.Imagem;
                if (!UploadArquivo(veiculoViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(veiculoViewModel);
                }

                veiculoViewModel.Imagem = imagemNome;
            }
            else
            {
                veiculoViewModel.Imagem = "NoImage.jpg";
            }

            await _veiculoService.Adicionar(_mapper.Map<Veiculo>(veiculoViewModel));

            return CustomResponse(veiculoViewModel);
        }

        [ClaimsAuthorize("Veiculo", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, VeiculoViewModel veiculoViewModel)
        {
            if (id != veiculoViewModel.Id)
            {
                NotificarErro("O id informado é diferente do id da requisição.");
                return CustomResponse();
            }

            var veiculoAtualizacao = await ObterVeiculo(id);

            if (string.IsNullOrEmpty(veiculoViewModel.Imagem))
                veiculoViewModel.Imagem = veiculoAtualizacao.Imagem;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (veiculoViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + veiculoViewModel.Imagem;
                if (!UploadArquivo(veiculoViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                veiculoAtualizacao.Imagem = imagemNome;
            }

            veiculoAtualizacao.Placa = veiculoViewModel.Placa;
            veiculoAtualizacao.UfPlaca = veiculoViewModel.UfPlaca;
            veiculoAtualizacao.Ano = veiculoViewModel.Ano;
            veiculoAtualizacao.Proprio = veiculoViewModel.Proprio;
            veiculoAtualizacao.KmAtual = veiculoViewModel.KmAtual;
            veiculoAtualizacao.Modelo = veiculoViewModel.Modelo;
            veiculoAtualizacao.Renavam = veiculoViewModel.Renavam;
            veiculoAtualizacao.TipoCombustivel = veiculoViewModel.TipoCombustivel;

            await _veiculoService.Atualizar(_mapper.Map<Veiculo>(veiculoAtualizacao));

            return CustomResponse(veiculoViewModel);
        }

        [ClaimsAuthorize("Veiculo", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<VeiculoViewModel>> Excluir(Guid id)
        {
            var veiculoViewModel = await ObterVeiculoPorId(id);

            if (veiculoViewModel == null)
            {
                NotificarErro("O id do veículo não foi encontrado.");
                return CustomResponse(veiculoViewModel);
            }

            await _veiculoService.Remover(id);

            return CustomResponse(veiculoViewModel);
        }
        #endregion

        #region METHODS
        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este veículo!");
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

        private async Task<VeiculoViewModel> ObterVeiculo(Guid id)
        {
            return _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorId(id));
        }

        [ClaimsAuthorize("Veiculo", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<VeiculoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterTodos());
        }

        [ClaimsAuthorize("Veiculo", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VeiculoViewModel>> ObterVeiculoPorId(Guid id)
        {
            var veiculo = _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorId(id));

            if (veiculo == null) return NotFound();

            return veiculo;
        }
        #endregion

    }
}