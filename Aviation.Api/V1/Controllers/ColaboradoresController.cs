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
    [Route("api/v{version:apiVersion}/colaboradores")]
    public class ColaboradoresController : MainController
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IColaboradorServices _colaboradorService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public ColaboradoresController(IColaboradorRepository colaboradorRepository,
                                  IColaboradorServices colaboradorService,
                                  IMapper mapper,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _colaboradorRepository = colaboradorRepository;
            _mapper = mapper;
            _colaboradorService = colaboradorService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Colaborador", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ColaboradorViewModel>> Adicionar(ColaboradorViewModel colaboradorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (colaboradorViewModel.Imagem != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + colaboradorViewModel.Imagem;
                if (!UploadArquivo(colaboradorViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(colaboradorViewModel);
                }

                colaboradorViewModel.Imagem = imagemNome;
            }
            else
            {
                colaboradorViewModel.Imagem = "NoImage.jpg";
            }

            await _colaboradorService.Adicionar(_mapper.Map<Colaborador>(colaboradorViewModel));

            return CustomResponse(colaboradorViewModel);
        }

        [ClaimsAuthorize("Colaborador", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ColaboradorViewModel>> Atualizar(Guid id, ColaboradorViewModel colaboradorViewModel)
        {
            if (id != colaboradorViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var colaboradorAtualizacao = await ObterColaborador(id);

            if (string.IsNullOrEmpty(colaboradorViewModel.Imagem))
                colaboradorViewModel.Imagem = colaboradorAtualizacao.Imagem;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (colaboradorViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + colaboradorViewModel.Imagem;
                if (!UploadArquivo(colaboradorViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                colaboradorAtualizacao.Imagem = imagemNome;
            }

            colaboradorAtualizacao.Nome = colaboradorViewModel.Nome;
            colaboradorAtualizacao.TipoPessoa = colaboradorViewModel.TipoPessoa;
            colaboradorAtualizacao.Documento = colaboradorViewModel.Documento;
            colaboradorAtualizacao.Sexo = colaboradorViewModel.Sexo;
            colaboradorAtualizacao.EstadoCivil = colaboradorViewModel.EstadoCivil;
            colaboradorAtualizacao.Ativo = colaboradorViewModel.Ativo;
            colaboradorAtualizacao.Telefone = colaboradorViewModel.Telefone;
            colaboradorAtualizacao.Email = colaboradorViewModel.Email;
            colaboradorAtualizacao.DataNascimento = colaboradorViewModel.DataNascimento;
            colaboradorAtualizacao.DataAdmissao = colaboradorViewModel.DataAdmissao;
            colaboradorAtualizacao.DataDemissao = colaboradorViewModel.DataDemissao;
            colaboradorAtualizacao.TipoColaborador = colaboradorViewModel.TipoColaborador;
            colaboradorAtualizacao.Cargo = colaboradorViewModel.Cargo;
            colaboradorAtualizacao.CANAC = colaboradorViewModel.CANAC;
            colaboradorAtualizacao.Salario = colaboradorViewModel.Salario;
            colaboradorAtualizacao.TipoVinculo = colaboradorViewModel.TipoVinculo;
            colaboradorAtualizacao.RG = colaboradorViewModel.RG;
            colaboradorAtualizacao.OrgaoEmissor = colaboradorViewModel.OrgaoEmissor;
            colaboradorAtualizacao.TituloEleitor = colaboradorViewModel.TituloEleitor;
            colaboradorAtualizacao.NumeroPis = colaboradorViewModel.NumeroPis;
            colaboradorAtualizacao.NumeroCtps = colaboradorViewModel.NumeroCtps;
            colaboradorAtualizacao.NumeroCnh = colaboradorViewModel.NumeroCnh;

            await _colaboradorService.Atualizar(_mapper.Map<Colaborador>(colaboradorAtualizacao));

            return CustomResponse(colaboradorViewModel);
        }

        [ClaimsAuthorize("Colaborador", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ColaboradorViewModel>> Excluir(Guid id)
        {
            var colaboradorViewModel = await ObterColaboradorPorId(id);

            if (colaboradorViewModel == null)
            {
                NotificarErro("O id do colaborador não foi encontrado.");
                return CustomResponse(colaboradorViewModel);
            }

            await _colaboradorService.Remover(id);

            return CustomResponse(colaboradorViewModel);
        }
        #endregion

        #region METHODS
        [AllowAnonymous]
        [HttpGet("{tipoColaborador:int}")]
        public async Task<IEnumerable<ColaboradorViewModel>> ObterTodos(TipoColaboradorEnum tipoColaborador)
        {
            return _mapper.Map<IEnumerable<ColaboradorViewModel>>(await _colaboradorRepository.ObterColaboradoresPorTipo(tipoColaborador));
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ColaboradorViewModel>> ObterColaboradorPorId(Guid id)
        {
            var colaborador = _mapper.Map<ColaboradorViewModel>(await _colaboradorRepository.ObterPorId(id));

            if (colaborador == null) return NotFound();

            return colaborador;
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este colaborador!");
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

        [HttpGet("quantidade/{tipoColaborador:int}")]
        public async Task<int> ObterQuantidadeColaboradoresCadastrados(TipoColaboradorEnum tipoColaborador)
        {
            return _mapper.Map<int>(await _colaboradorRepository.ObterQuantidadeColaboradoresCadastrados(tipoColaborador));
        }

        private async Task<ColaboradorViewModel> ObterColaborador(Guid id)
        {
            return _mapper.Map<ColaboradorViewModel>(await _colaboradorRepository.ObterPorId(id));
        }
        #endregion
    }
}