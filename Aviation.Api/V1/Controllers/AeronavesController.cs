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
    [Route("api/v{version:apiVersion}/aeronaves")]
    public class AeronavesController : MainController
    {
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly IAeronaveServices _aeronaveService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public AeronavesController(IAeronaveRepository aeronaveRepository,
                                  IAeronaveServices aeronaveService,
                                  IMapper mapper,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _aeronaveRepository = aeronaveRepository;
            _mapper = mapper;
            _aeronaveService = aeronaveService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Aeronave", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<AeronaveViewModel>> Adicionar(AeronaveViewModel aeronaveViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (aeronaveViewModel.Imagem != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + aeronaveViewModel.Imagem;
                if (!UploadArquivo(aeronaveViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(aeronaveViewModel);
                }

                aeronaveViewModel.Imagem = imagemNome;
            }
            else
            {
                aeronaveViewModel.Imagem = "NoImage.jpg";
            }

            aeronaveViewModel.HorasRestantes = aeronaveViewModel.ProximaIntervencao - aeronaveViewModel.HorasTotais;

            await _aeronaveService.Adicionar(_mapper.Map<Aeronave>(aeronaveViewModel));

            return CustomResponse(aeronaveViewModel);
        }

        [ClaimsAuthorize("Aeronave", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AeronaveViewModel>> Atualizar(Guid id, AeronaveViewModel aeronaveViewModel)
        {
            if (id != aeronaveViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var aeronaveAtualizacao = await ObterAeronave(id);

            if (string.IsNullOrEmpty(aeronaveViewModel.Imagem))
                aeronaveViewModel.Imagem = aeronaveAtualizacao.Imagem;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (aeronaveViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + aeronaveViewModel.Imagem;
                if (!UploadArquivo(aeronaveViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                aeronaveAtualizacao.Imagem = imagemNome;
            }

            aeronaveAtualizacao.Matricula = aeronaveViewModel.Matricula;
            aeronaveAtualizacao.Fabricante = aeronaveViewModel.Fabricante;
            aeronaveAtualizacao.Categoria = aeronaveViewModel.Categoria;
            aeronaveAtualizacao.Modelo = aeronaveViewModel.Modelo;
            aeronaveAtualizacao.NumeroSerie = aeronaveViewModel.NumeroSerie;
            aeronaveAtualizacao.Ano = aeronaveViewModel.Ano;
            aeronaveAtualizacao.PesoVazio = aeronaveViewModel.PesoVazio;
            aeronaveAtualizacao.PesoBasico = aeronaveViewModel.PesoBasico;
            aeronaveAtualizacao.HorasTotais = aeronaveViewModel.HorasTotais;
            aeronaveAtualizacao.ProximaIntervencao = aeronaveViewModel.ProximaIntervencao;
            aeronaveAtualizacao.TipoAeronave = aeronaveViewModel.TipoAeronave;
            aeronaveAtualizacao.UltimaPesagem = aeronaveViewModel.UltimaPesagem;
            aeronaveAtualizacao.ProximaPesagem = aeronaveViewModel.ProximaPesagem;
            aeronaveAtualizacao.Situacao = aeronaveViewModel.Situacao;
            aeronaveAtualizacao.Ativo = aeronaveViewModel.Ativo;
            
            aeronaveAtualizacao.HorasRestantes = aeronaveViewModel.ProximaIntervencao - aeronaveViewModel.HorasTotais;

            await _aeronaveService.Atualizar(_mapper.Map<Aeronave>(aeronaveAtualizacao));

            return CustomResponse(aeronaveViewModel);
        }

        [ClaimsAuthorize("Aeronave", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AeronaveViewModel>> Excluir(Guid id)
        {
            var aeronaveViewModel = await ObterAeronave(id);

            if (aeronaveViewModel == null)
            {
                NotificarErro("O id da aeronave não foi encontrado.");
                return CustomResponse(aeronaveViewModel);
            }

            await _aeronaveService.Remover(id);

            return CustomResponse(aeronaveViewModel);
        }

        [ClaimsAuthorize("Aeronave", "Atualizar")]
        [HttpPut("liberar/{id:guid}")]
        public async Task<ActionResult<AeronaveViewModel>> LiberarAeronave(Guid id)
        {
            var aeronaveAtualizacao = await ObterAeronave(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            // ALTERAÇÃO PARA OPERACIONAL!! TRUE
            aeronaveAtualizacao.Situacao = true;

            await _aeronaveService.Atualizar(_mapper.Map<Aeronave>(aeronaveAtualizacao));

            return CustomResponse(aeronaveAtualizacao);
        }

        [ClaimsAuthorize("Aeronave", "Atualizar")]
        [HttpPut("parar/{id:guid}")]
        public async Task<ActionResult<AeronaveViewModel>> PararAeronave(Guid id)
        {
            var aeronaveAtualizacao = await ObterAeronave(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            // ALTERAÇÃO PARA APROVADO!! FALSE
            aeronaveAtualizacao.Situacao = false;

            await _aeronaveService.Atualizar(_mapper.Map<Aeronave>(aeronaveAtualizacao));

            return CustomResponse(aeronaveAtualizacao);
        }

        // SALDO INSTRUÇÃO
        [ClaimsAuthorize("Aeronave", "Atualizar")]
        [HttpPut("atualizar-total/{id:guid}")]
        public async Task<ActionResult<AeronaveViewModel>> AtualizarHora(Guid id, AeronaveHorasTotaisViewModel aeronaveHorasTotaisViewModel)
        {
            if (id != aeronaveHorasTotaisViewModel.Id)
            {
                NotificarErro("O id informado é diferente do id da requisição.");
                return CustomResponse();
            }

            var aeronaveAtualizacao = await ObterAeronave(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            // MANTÉM TUDO
            aeronaveAtualizacao.Matricula = aeronaveAtualizacao.Matricula;
            aeronaveAtualizacao.Fabricante = aeronaveAtualizacao.Fabricante;
            aeronaveAtualizacao.Categoria = aeronaveAtualizacao.Categoria;
            aeronaveAtualizacao.Modelo = aeronaveAtualizacao.Modelo;
            aeronaveAtualizacao.NumeroSerie = aeronaveAtualizacao.NumeroSerie;
            aeronaveAtualizacao.Ano = aeronaveAtualizacao.Ano;
            aeronaveAtualizacao.PesoVazio = aeronaveAtualizacao.PesoVazio;
            aeronaveAtualizacao.PesoBasico = aeronaveAtualizacao.PesoBasico;
            aeronaveAtualizacao.ProximaIntervencao = aeronaveAtualizacao.ProximaIntervencao;
            aeronaveAtualizacao.TipoAeronave = aeronaveAtualizacao.TipoAeronave;
            aeronaveAtualizacao.UltimaPesagem = aeronaveAtualizacao.UltimaPesagem;
            aeronaveAtualizacao.ProximaPesagem = aeronaveAtualizacao.ProximaPesagem;
            aeronaveAtualizacao.Situacao = aeronaveAtualizacao.Situacao;
            aeronaveAtualizacao.Ativo = aeronaveAtualizacao.Ativo;
            aeronaveAtualizacao.Imagem = aeronaveAtualizacao.Imagem;

            aeronaveAtualizacao.HorasTotais += aeronaveHorasTotaisViewModel.TotalDecimal;
            aeronaveAtualizacao.HorasRestantes = aeronaveAtualizacao.ProximaIntervencao - aeronaveAtualizacao.HorasTotais;

            await _aeronaveService.Atualizar(_mapper.Map<Aeronave>(aeronaveAtualizacao));

            return CustomResponse(aeronaveHorasTotaisViewModel);
        }
        #endregion

        #region METHODS
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

        [ClaimsAuthorize("Aeronave", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<AeronaveViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AeronaveViewModel>>(await _aeronaveRepository.ObterTodos());
        }

        [HttpGet("quantidade")]
        public async Task<int> ObterQuantidadeAeronavesCadastradas()
        {
            return _mapper.Map<int>(await _aeronaveRepository.ObterTotalRegistros());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AeronaveViewModel>> ObterAeronavePorId(Guid id)
        {
            var aeronave = _mapper.Map<AeronaveViewModel>(await _aeronaveRepository.ObterPorId(id));

            if (aeronave == null) return NotFound();

            return aeronave;
        }

        private async Task<AeronaveViewModel> ObterAeronave(Guid id)
        {
            return _mapper.Map<AeronaveViewModel>(await _aeronaveRepository.ObterPorId(id));
        }
        #endregion
    }
}