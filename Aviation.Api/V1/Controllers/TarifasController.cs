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

namespace AviationManagementApi.App.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/aeronaves/tarifas")]
    public class TarifasController : MainController
    {
        private readonly IAeronaveTarifaRepository _tarifaRepository;
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly IAeronaveTarifaServices _tarifaService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public TarifasController(IAeronaveTarifaRepository tarifaRepository,
                                IAeronaveRepository aeronaveRepository,
                                IMapper mapper,
                                IAeronaveTarifaServices tarifaService,
                                INotificador notificador, IUser user) : base(notificador, user)
        {
            _tarifaRepository = tarifaRepository;
            _aeronaveRepository = aeronaveRepository;
            _mapper = mapper;
            _tarifaService = tarifaService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Tarifa", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<AeronaveTarifaViewModel>> Adicionar(AeronaveTarifaViewModel aeronaveTarifaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _tarifaService.Adicionar(_mapper.Map<AeronaveTarifa>(aeronaveTarifaViewModel));

            return CustomResponse(aeronaveTarifaViewModel);
        }

        [ClaimsAuthorize("Tarifa", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AeronaveTarifaViewModel>> Atualizar(Guid id, AeronaveTarifaViewModel aeronaveTarifaViewModel)
        {
            if (id != aeronaveTarifaViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var aeronaveTarifaAtualizacao = await ObterAeronaveTarifa(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            aeronaveTarifaAtualizacao.Data = aeronaveTarifaViewModel.Data;
            aeronaveTarifaAtualizacao.Vencimento = aeronaveTarifaViewModel.Vencimento;
            aeronaveTarifaAtualizacao.Valor = aeronaveTarifaViewModel.Valor;
            aeronaveTarifaAtualizacao.Situacao = aeronaveTarifaViewModel.Situacao;
            aeronaveTarifaAtualizacao.Numeracao = aeronaveTarifaViewModel.Numeracao;
            aeronaveTarifaAtualizacao.OrgaoEmissorTarifa = aeronaveTarifaViewModel.OrgaoEmissorTarifa;
            aeronaveTarifaAtualizacao.AeronaveId = aeronaveTarifaViewModel.AeronaveId;

            await _tarifaService.Atualizar(_mapper.Map<AeronaveTarifa>(aeronaveTarifaAtualizacao));

            return CustomResponse(aeronaveTarifaViewModel);
        }

        [ClaimsAuthorize("Tarifa", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AeronaveTarifaViewModel>> Excluir(Guid id)
        {
            var aeronaveTarifa = await ObterAeronaveTarifa(id);

            if (aeronaveTarifa == null)
            {
                NotificarErro("O id da tarifa não foi encontrado.");
                return CustomResponse(aeronaveTarifa);
            }

            await _tarifaService.Remover(id);

            return CustomResponse(aeronaveTarifa);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Tarifa", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<AeronaveTarifaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AeronaveTarifaViewModel>>(await _tarifaRepository.ObterTarifasAeronaves());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AeronaveTarifaViewModel>> ObterAeronaveTarifaPorId(Guid id)
        {
            var aeronaveTarifa = _mapper.Map<AeronaveTarifaViewModel>(await _tarifaRepository.ObterTarifaAeronave(id));

            if (aeronaveTarifa == null) return NotFound();

            return aeronaveTarifa;
        }

        [AllowAnonymous]
        [HttpGet("infraero")]
        public async Task<IEnumerable<AeronaveTarifaViewModel>> ObterTodasInfraero()
        {
            return _mapper.Map<IEnumerable<AeronaveTarifaViewModel>>(await _tarifaRepository.ObterTarifasInfraeroAeronaves());
        }

        [AllowAnonymous]
        [HttpGet("decea")]
        public async Task<IEnumerable<AeronaveTarifaViewModel>> ObterTodasDecea()
        {
            return _mapper.Map<IEnumerable<AeronaveTarifaViewModel>>(await _tarifaRepository.ObterTarifasDeceaAeronaves());
        }

        [AllowAnonymous]
        [HttpGet("infraero/{id:guid}")]
        public async Task<ActionResult<AeronaveTarifaViewModel>> ObterTarifaInfraeroPorId(Guid id)
        {
            var aeronaveTarifaInfraero = _mapper.Map<AeronaveTarifaViewModel>(await _tarifaRepository.ObterTarifaInfraeroAeronave(id));
            
            if (aeronaveTarifaInfraero == null) return NotFound();

            return aeronaveTarifaInfraero;
        }

        [AllowAnonymous]
        [HttpGet("decea/{id:guid}")]
        public async Task<ActionResult<AeronaveTarifaViewModel>> ObterTarifaDeceaPorId(Guid id)
        {
            var aeronaveTarifaDecea = _mapper.Map<AeronaveTarifaViewModel>(await _tarifaRepository.ObterTarifaDeceaAeronave(id));

            if (aeronaveTarifaDecea == null) return NotFound();

            return aeronaveTarifaDecea;
        }

        private async Task<AeronaveTarifaViewModel> ObterAeronaveTarifa(Guid id)
        {
            return _mapper.Map<AeronaveTarifaViewModel>(await _tarifaRepository.ObterTarifaAeronave(id));
        }
        #endregion
    }
}
