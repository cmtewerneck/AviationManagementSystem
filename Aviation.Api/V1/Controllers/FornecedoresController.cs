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

namespace AviationManagementApi.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/fornecedores")]
    public class FornecedoresController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorServices _fornecedorService;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                      IMapper mapper,
                                      IFornecedorServices fornecedorService,
                                      IEnderecoRepository enderecoRepository,
                                      INotificador notificador, IUser user) : base(notificador, user)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _enderecoRepository = enderecoRepository;
            _fornecedorService = fornecedorService;
        }

        [ClaimsAuthorize("Fornecedor", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> ObterPorId(Guid id)
        {
            var fornecedor = await ObterFornecedorProdutosEndereco(id);

            if (fornecedor == null) return NotFound();

            return fornecedor;
        }

        //private async Task<FornecedorViewModel> ObterFornecedorProdutos(Guid id)
        //{
        //    return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutos(id));
        //}

        //private async Task<FornecedorViewModel> ObterFornecedor(Guid id)
        //{
        //    return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedor(id));
        //}

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }

        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }

        [ClaimsAuthorize("Fornecedor", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<FornecedorViewModel>> Adicionar(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (fornecedorViewModel.Imagem != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + fornecedorViewModel.Imagem;
                if (!UploadArquivo(fornecedorViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(fornecedorViewModel);
                }

                fornecedorViewModel.Imagem = imagemNome;
            }
            else
            {
                fornecedorViewModel.Imagem = "NoImage.jpg";
            }

            await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorViewModel));

            return CustomResponse(fornecedorViewModel);
        }

        [ClaimsAuthorize("Fornecedor", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Atualizar(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var fornecedorAtualizacao = await ObterFornecedorEndereco(id);

            if (string.IsNullOrEmpty(fornecedorViewModel.Imagem))
                fornecedorViewModel.Imagem = fornecedorAtualizacao.Imagem;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (fornecedorViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + fornecedorViewModel.Imagem;
                if (!UploadArquivo(fornecedorViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                fornecedorAtualizacao.Imagem = imagemNome;
            }

            fornecedorAtualizacao.Nome = fornecedorViewModel.Nome;
            fornecedorAtualizacao.TipoPessoa = fornecedorViewModel.TipoPessoa;
            fornecedorAtualizacao.Documento = fornecedorViewModel.Documento;
            fornecedorAtualizacao.Sexo = fornecedorViewModel.Sexo;
            fornecedorAtualizacao.EstadoCivil = fornecedorViewModel.EstadoCivil;
            fornecedorAtualizacao.Ativo = fornecedorViewModel.Ativo;
            fornecedorAtualizacao.Telefone = fornecedorViewModel.Telefone;
            fornecedorAtualizacao.Email = fornecedorViewModel.Email;

            await _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(fornecedorAtualizacao));

            return CustomResponse(fornecedorViewModel);
        }

        [ClaimsAuthorize("Fornecedor", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if (fornecedorViewModel == null)
            {
                NotificarErro("O id do fornecedor não foi encontrado.");
                return CustomResponse(fornecedorViewModel);
            }

            await _fornecedorService.Remover(id);

            return CustomResponse(fornecedorViewModel);
        }

        [ClaimsAuthorize("Fornecedor", "Atualizar")]
        [HttpPut("endereco/{id:guid}")]
        public async Task<IActionResult> AtualizarEndereco(Guid id, EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(enderecoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _fornecedorService.AtualizarEndereco(_mapper.Map<Endereco>(enderecoViewModel));

            return CustomResponse(enderecoViewModel);
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este fornecedor!");
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
    }
}
