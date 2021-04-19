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
    [Route("api/v{version:apiVersion}/aeronaves/diretrizes")]
    public class AeronavesDiretrizesController : MainController
    {
        private readonly IAeronaveDiretrizRepository _aeronaveDiretrizRepository;
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly IAeronaveDiretrizService _aeronaveDiretrizService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public AeronavesDiretrizesController(IAeronaveDiretrizRepository aeronaveDiretrizRepository,
                                  IAeronaveRepository aeronaveRepository,
                                  IMapper mapper,
                                  IAeronaveDiretrizService aeronaveDiretrizService,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _aeronaveDiretrizRepository = aeronaveDiretrizRepository;
            _aeronaveRepository = aeronaveRepository;
            _mapper = mapper;
            _aeronaveDiretrizService = aeronaveDiretrizService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Diretriz", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<AeronaveDiretrizViewModel>> Adicionar(AeronaveDiretrizViewModel aeronaveDiretrizViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _aeronaveDiretrizService.Adicionar(_mapper.Map<AeronaveDiretriz>(aeronaveDiretrizViewModel));

            return CustomResponse(aeronaveDiretrizViewModel);
        }

        [ClaimsAuthorize("Diretriz", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AeronaveDiretrizViewModel>> Atualizar(Guid id, AeronaveDiretrizViewModel aeronaveDiretrizViewModel)
        {
            if (id != aeronaveDiretrizViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var aeronaveDiretrizAtualizacao = await ObterAeronaveDiretriz(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            aeronaveDiretrizAtualizacao.Titulo = aeronaveDiretrizViewModel.Titulo;
            aeronaveDiretrizAtualizacao.Referencia = aeronaveDiretrizViewModel.Referencia;
            aeronaveDiretrizAtualizacao.DataEfetivacao = aeronaveDiretrizViewModel.DataEfetivacao;
            aeronaveDiretrizAtualizacao.Descricao = aeronaveDiretrizViewModel.Descricao;
            aeronaveDiretrizAtualizacao.TipoDiretriz = aeronaveDiretrizViewModel.TipoDiretriz;
            aeronaveDiretrizAtualizacao.IntervaloHoras = aeronaveDiretrizViewModel.IntervaloHoras;
            aeronaveDiretrizAtualizacao.IntervaloCiclos = aeronaveDiretrizViewModel.IntervaloCiclos;
            aeronaveDiretrizAtualizacao.IntervaloDias = aeronaveDiretrizViewModel.IntervaloDias;
            aeronaveDiretrizAtualizacao.UltimoCumprimentoCiclos = aeronaveDiretrizViewModel.UltimoCumprimentoCiclos;
            aeronaveDiretrizAtualizacao.UltimoCumprimentoData = aeronaveDiretrizViewModel.UltimoCumprimentoData;
            aeronaveDiretrizAtualizacao.UltimoCumprimentoHoras = aeronaveDiretrizViewModel.UltimoCumprimentoHoras;
            aeronaveDiretrizAtualizacao.Observacoes = aeronaveDiretrizViewModel.Observacoes;
            aeronaveDiretrizAtualizacao.Status = aeronaveDiretrizViewModel.Status;
            aeronaveDiretrizAtualizacao.AeronaveId = aeronaveDiretrizViewModel.AeronaveId;

            await _aeronaveDiretrizService.Atualizar(_mapper.Map<AeronaveDiretriz>(aeronaveDiretrizAtualizacao));

            return CustomResponse(aeronaveDiretrizViewModel);
        }

        [ClaimsAuthorize("Diretriz", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AeronaveDiretrizViewModel>> Excluir(Guid id)
        {
            var aeronaveDiretriz = await ObterAeronaveDiretriz(id);

            if (aeronaveDiretriz == null)
            {
                NotificarErro("O id da diretriz não foi encontrado.");
                return CustomResponse(aeronaveDiretriz);
            }

            await _aeronaveDiretrizService.Remover(id);

            return CustomResponse(aeronaveDiretriz);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Diretriz", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<AeronaveDiretrizViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AeronaveDiretrizViewModel>>(await _aeronaveDiretrizRepository.ObterDiretrizesAeronaves());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AeronaveDiretrizViewModel>> ObterDiretrizPorId(Guid id)
        {
            var aeronaveDiretriz = _mapper.Map<AeronaveDiretrizViewModel>(await _aeronaveDiretrizRepository.ObterDiretrizAeronave(id));

            if (aeronaveDiretriz == null) return NotFound();

            return aeronaveDiretriz;
        }

        private async Task<AeronaveDiretrizViewModel> ObterAeronaveDiretriz(Guid id)
        {
            return _mapper.Map<AeronaveDiretrizViewModel>(await _aeronaveDiretrizRepository.ObterPorId(id));
        }
        #endregion
    }
}
