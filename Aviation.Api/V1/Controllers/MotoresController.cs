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
    [Route("api/v{version:apiVersion}/aeronaves/motores")]
    public class MotoresController : MainController
    {
        private readonly IAeronaveMotorRepository _aeronaveMotorRepository;
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly IAeronaveMotorService _aeronaveMotorService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public MotoresController(IAeronaveMotorRepository aeronaveMotorRepository,
                                  IAeronaveRepository aeronaveRepository,
                                  IMapper mapper,
                                  IAeronaveMotorService aeronaveMotorService,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _aeronaveMotorRepository = aeronaveMotorRepository;
            _aeronaveRepository = aeronaveRepository;
            _mapper = mapper;
            _aeronaveMotorService = aeronaveMotorService;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Motor", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<AeronaveMotorViewModel>> Adicionar(AeronaveMotorViewModel aeronaveMotorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _aeronaveMotorService.Adicionar(_mapper.Map<AeronaveMotor>(aeronaveMotorViewModel));

            return CustomResponse(aeronaveMotorViewModel);
        }

        [ClaimsAuthorize("Motor", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AeronaveMotorViewModel>> Atualizar(Guid id, AeronaveMotorViewModel aeronaveMotorViewModel)
        {
            if (id != aeronaveMotorViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var aeronaveMotorAtualizacao = await ObterAeronaveMotor(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            aeronaveMotorAtualizacao.Fabricante = aeronaveMotorViewModel.Fabricante;
            aeronaveMotorAtualizacao.Modelo = aeronaveMotorViewModel.Modelo;
            aeronaveMotorAtualizacao.NumeroSerie = aeronaveMotorViewModel.NumeroSerie;
            aeronaveMotorAtualizacao.CiclosTotais = aeronaveMotorViewModel.CiclosTotais;
            aeronaveMotorAtualizacao.HorasTotais = aeronaveMotorViewModel.HorasTotais;
            aeronaveMotorAtualizacao.AeronaveId = aeronaveMotorViewModel.AeronaveId;

            await _aeronaveMotorService.Atualizar(_mapper.Map<AeronaveMotor>(aeronaveMotorAtualizacao));

            return CustomResponse(aeronaveMotorViewModel);
        }

        [ClaimsAuthorize("Motor", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AeronaveMotorViewModel>> Excluir(Guid id)
        {
            var aeronaveMotorAeronave = await ObterAeronaveMotor(id);

            if (aeronaveMotorAeronave == null)
            {
                NotificarErro("O id do Motor não foi encontrado.");
                return CustomResponse(aeronaveMotorAeronave);
            }

            await _aeronaveMotorService.Remover(id);

            return CustomResponse(aeronaveMotorAeronave);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Motor", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<AeronaveMotorViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AeronaveMotorViewModel>>(await _aeronaveMotorRepository.ObterMotoresAeronaves());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AeronaveMotorViewModel>> ObterMotorPorId(Guid id)
        {
            var aeronaveMotor = _mapper.Map<AeronaveMotorViewModel>(await _aeronaveMotorRepository.ObterMotorAeronave(id));

            if (aeronaveMotor == null) return NotFound();

            return aeronaveMotor;
        }

        private async Task<AeronaveMotorViewModel> ObterAeronaveMotor(Guid id)
        {
            return _mapper.Map<AeronaveMotorViewModel>(await _aeronaveMotorRepository.ObterPorId(id));
        }
        #endregion
    }
}
