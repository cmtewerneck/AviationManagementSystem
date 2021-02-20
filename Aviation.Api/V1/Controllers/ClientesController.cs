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
    [Route("api/v{version:apiVersion}/clientes")]
    public class ClientesController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteServices _clienteService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public ClientesController(IClienteRepository clienteRepository, 
                                  IClienteServices clienteService,
                                  IMapper mapper, 
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _clienteService = clienteService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Cliente", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> Adicionar(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (clienteViewModel.Imagem != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + clienteViewModel.Imagem;
                if (!UploadArquivo(clienteViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(clienteViewModel);
                }

                clienteViewModel.Imagem = imagemNome;
            }
            else
            {
                clienteViewModel.Imagem = "NoImage.jpg";
            }

            await _clienteService.Adicionar(_mapper.Map<Cliente>(clienteViewModel));

            return CustomResponse(clienteViewModel);
        }

        [ClaimsAuthorize("Cliente", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> Atualizar(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var clienteAtualizacao = await ObterCliente(id);

            if (string.IsNullOrEmpty(clienteViewModel.Imagem))
                clienteViewModel.Imagem = clienteAtualizacao.Imagem;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (clienteViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + clienteViewModel.Imagem;
                if (!UploadArquivo(clienteViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                clienteAtualizacao.Imagem = imagemNome;
            }

            clienteAtualizacao.Nome = clienteViewModel.Nome;
            clienteAtualizacao.TipoPessoa = clienteViewModel.TipoPessoa;
            clienteAtualizacao.Documento = clienteViewModel.Documento;
            clienteAtualizacao.Sexo = clienteViewModel.Sexo;
            clienteAtualizacao.EstadoCivil = clienteViewModel.EstadoCivil;
            clienteAtualizacao.Ativo = clienteViewModel.Ativo;
            clienteAtualizacao.Telefone = clienteViewModel.Telefone;
            clienteAtualizacao.Email = clienteViewModel.Email;

            await _clienteService.Atualizar(_mapper.Map<Cliente>(clienteAtualizacao));

            return CustomResponse(clienteViewModel);
        }

        [ClaimsAuthorize("Cliente", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> Excluir(Guid id)
        {
            var clienteViewModel = await ObterCliente(id);

            if (clienteViewModel == null)
            {
                NotificarErro("O id do fornecedor não foi encontrado.");
                return CustomResponse(clienteViewModel);
            }

            await _clienteService.Remover(id);

            return CustomResponse(clienteViewModel);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Cliente", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<ClienteViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());
        }

        [ClaimsAuthorize("Cliente", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> ObterClientePorId(Guid id)
        {
            var cliente = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));

            if (cliente == null) return NotFound();

            return cliente;
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

        private async Task<ClienteViewModel> ObterCliente(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));
        }
        #endregion
    }
}