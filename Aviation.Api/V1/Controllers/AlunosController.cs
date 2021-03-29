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
    [Route("api/v{version:apiVersion}/alunos")]
    public class AlunosController : MainController
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAlunoServices _alunoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public AlunosController(IAlunoRepository alunoRepository,
                                  IAlunoServices alunoService,
                                  IMapper mapper,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
            _alunoService = alunoService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Aluno", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<AlunoViewModel>> Adicionar(AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (alunoViewModel.Imagem != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + alunoViewModel.Imagem;
                if (!UploadArquivo(alunoViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(alunoViewModel);
                }

                alunoViewModel.Imagem = imagemNome;
            }
            else
            {
                alunoViewModel.Imagem = "NoImage.jpg";
            }

            await _alunoService.Adicionar(_mapper.Map<Aluno>(alunoViewModel));

            return CustomResponse(alunoViewModel);
        }

        [ClaimsAuthorize("Aluno", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AlunoViewModel>> Atualizar(Guid id, AlunoViewModel alunoViewModel)
        {
            if (id != alunoViewModel.Id)
            {
                NotificarErro("O id informado é diferente do id da requisição.");
                return CustomResponse();
            }

            var alunoAtualizacao = await ObterAluno(id);

            if (string.IsNullOrEmpty(alunoViewModel.Imagem))
                alunoViewModel.Imagem = alunoAtualizacao.Imagem;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (alunoViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + alunoViewModel.Imagem;
                if (!UploadArquivo(alunoViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                alunoAtualizacao.Imagem = imagemNome;
            }

            alunoAtualizacao.Nome = alunoViewModel.Nome;
            alunoAtualizacao.TipoPessoa = alunoViewModel.TipoPessoa;
            alunoAtualizacao.Documento = alunoViewModel.Documento;
            alunoAtualizacao.Sexo = alunoViewModel.Sexo;
            alunoAtualizacao.EstadoCivil = alunoViewModel.EstadoCivil;
            alunoAtualizacao.Ativo = alunoViewModel.Ativo;
            alunoAtualizacao.Telefone = alunoViewModel.Telefone;
            alunoAtualizacao.Email = alunoViewModel.Email;
            alunoAtualizacao.RG = alunoViewModel.RG;
            alunoAtualizacao.CANAC = alunoViewModel.CANAC;
            alunoAtualizacao.TotalVoado = alunoViewModel.TotalVoado;
            alunoAtualizacao.Saldo = alunoViewModel.Saldo;
            alunoAtualizacao.DataNascimento = alunoViewModel.DataNascimento;
            alunoAtualizacao.ValidadeCMA = alunoViewModel.ValidadeCMA;

            await _alunoService.Atualizar(_mapper.Map<Aluno>(alunoAtualizacao));

            return CustomResponse(alunoViewModel);
        }

        [ClaimsAuthorize("Aluno", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AlunoViewModel>> Excluir(Guid id)
        {
            var aluno = await ObterAluno(id);

            if (aluno == null)
            {
                NotificarErro("O id do aluno não foi encontrado.");
                return CustomResponse(aluno);
            }

            await _alunoService.Remover(id);

            return CustomResponse(aluno);
        }

        // SALDO INSTRUÇÃO
        [ClaimsAuthorize("Aluno", "Atualizar")]
        [HttpPut("atualizar-saldo/{id:guid}")]
        public async Task<ActionResult<AlunoSaldoViewModel>> AtualizarQuantidade(Guid id, AlunoSaldoViewModel alunoSaldoViewModel)
        {
            if (id != alunoSaldoViewModel.Id)
            {
                NotificarErro("O id informado é diferente do id da requisição.");
                return CustomResponse();
            }

            var alunoSaldoAtualizacao = await ObterAluno(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            // MANTÉM TUDO
            alunoSaldoAtualizacao.Nome = alunoSaldoAtualizacao.Nome;
            alunoSaldoAtualizacao.TipoPessoa = alunoSaldoAtualizacao.TipoPessoa;
            alunoSaldoAtualizacao.Documento = alunoSaldoAtualizacao.Documento;
            alunoSaldoAtualizacao.Sexo = alunoSaldoAtualizacao.Sexo;
            alunoSaldoAtualizacao.EstadoCivil = alunoSaldoAtualizacao.EstadoCivil;
            alunoSaldoAtualizacao.Ativo = alunoSaldoAtualizacao.Ativo;
            alunoSaldoAtualizacao.Telefone = alunoSaldoAtualizacao.Telefone;
            alunoSaldoAtualizacao.Email = alunoSaldoAtualizacao.Email;
            alunoSaldoAtualizacao.RG = alunoSaldoAtualizacao.RG;
            alunoSaldoAtualizacao.CANAC = alunoSaldoAtualizacao.CANAC;
            alunoSaldoAtualizacao.DataNascimento = alunoSaldoAtualizacao.DataNascimento;
            alunoSaldoAtualizacao.ValidadeCMA = alunoSaldoAtualizacao.ValidadeCMA;
            alunoSaldoAtualizacao.Imagem = alunoSaldoAtualizacao.Imagem;

            // ALTERA O SALDO E O TOTAL VOADO
            alunoSaldoAtualizacao.TotalVoado += alunoSaldoViewModel.TempoVoo;
            alunoSaldoAtualizacao.Saldo -= alunoSaldoViewModel.TempoVoo;

            await _alunoService.Atualizar(_mapper.Map<Aluno>(alunoSaldoAtualizacao));

            return CustomResponse(alunoSaldoViewModel);
        }

        [ClaimsAuthorize("Aluno", "Atualizar")]
        [HttpPut("adicionar-saldo/{id:guid}")]
        public async Task<ActionResult<AlunoViewModel>> AdicionarSaldo(Guid id, AlunoViewModel alunoViewModel)
        {
            if (id != alunoViewModel.Id)
            {
                NotificarErro("O id informado é diferente do id da requisição.");
                return CustomResponse();
            }

            var alunoAtualizacao = await ObterAluno(id);

            if (string.IsNullOrEmpty(alunoViewModel.Imagem))
                alunoViewModel.Imagem = alunoAtualizacao.Imagem;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (alunoViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + alunoViewModel.Imagem;
                if (!UploadArquivo(alunoViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                alunoAtualizacao.Imagem = imagemNome;
            }

            alunoAtualizacao.Nome = alunoViewModel.Nome;
            alunoAtualizacao.TipoPessoa = alunoViewModel.TipoPessoa;
            alunoAtualizacao.Documento = alunoViewModel.Documento;
            alunoAtualizacao.Sexo = alunoViewModel.Sexo;
            alunoAtualizacao.EstadoCivil = alunoViewModel.EstadoCivil;
            alunoAtualizacao.Ativo = alunoViewModel.Ativo;
            alunoAtualizacao.Telefone = alunoViewModel.Telefone;
            alunoAtualizacao.Email = alunoViewModel.Email;
            alunoAtualizacao.RG = alunoViewModel.RG;
            alunoAtualizacao.CANAC = alunoViewModel.CANAC;
            alunoAtualizacao.TotalVoado = alunoViewModel.TotalVoado;
            alunoAtualizacao.DataNascimento = alunoViewModel.DataNascimento;
            alunoAtualizacao.ValidadeCMA = alunoViewModel.ValidadeCMA;

            alunoAtualizacao.Saldo += alunoViewModel.Saldo;

            await _alunoService.Atualizar(_mapper.Map<Aluno>(alunoAtualizacao));

            return CustomResponse(alunoViewModel);
        }

        [ClaimsAuthorize("Aluno", "Atualizar")]
        [HttpPut("remover-saldo/{id:guid}")]
        public async Task<ActionResult<AlunoViewModel>> RemoverSaldo(Guid id, AlunoViewModel alunoViewModel)
        {
            if (id != alunoViewModel.Id)
            {
                NotificarErro("O id informado é diferente do id da requisição.");
                return CustomResponse();
            }

            var alunoAtualizacao = await ObterAluno(id);

            if (string.IsNullOrEmpty(alunoViewModel.Imagem))
                alunoViewModel.Imagem = alunoAtualizacao.Imagem;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (alunoViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + alunoViewModel.Imagem;
                if (!UploadArquivo(alunoViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                alunoAtualizacao.Imagem = imagemNome;
            }

            alunoAtualizacao.Nome = alunoViewModel.Nome;
            alunoAtualizacao.TipoPessoa = alunoViewModel.TipoPessoa;
            alunoAtualizacao.Documento = alunoViewModel.Documento;
            alunoAtualizacao.Sexo = alunoViewModel.Sexo;
            alunoAtualizacao.EstadoCivil = alunoViewModel.EstadoCivil;
            alunoAtualizacao.Ativo = alunoViewModel.Ativo;
            alunoAtualizacao.Telefone = alunoViewModel.Telefone;
            alunoAtualizacao.Email = alunoViewModel.Email;
            alunoAtualizacao.RG = alunoViewModel.RG;
            alunoAtualizacao.CANAC = alunoViewModel.CANAC;
            alunoAtualizacao.TotalVoado = alunoViewModel.TotalVoado;
            alunoAtualizacao.DataNascimento = alunoViewModel.DataNascimento;
            alunoAtualizacao.ValidadeCMA = alunoViewModel.ValidadeCMA;

            alunoAtualizacao.Saldo -= alunoViewModel.Saldo;

            await _alunoService.Atualizar(_mapper.Map<Aluno>(alunoAtualizacao));

            return CustomResponse(alunoViewModel);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Aluno", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<AlunoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AlunoViewModel>>(await _alunoRepository.ObterTodos());
        }

        [ClaimsAuthorize("Aluno", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AlunoViewModel>> ObterAlunoPorId(Guid id)
        {
            var aluno = _mapper.Map<AlunoViewModel>(await _alunoRepository.ObterPorId(id));

            if (aluno == null) return NotFound();

            return aluno;
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este aluno!");
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

        private async Task<AlunoViewModel> ObterAluno(Guid id)
        {
            return _mapper.Map<AlunoViewModel>(await _alunoRepository.ObterPorId(id));
        }
        #endregion
    }
}
