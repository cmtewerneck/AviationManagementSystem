using AutoMapper;
using AviationManagementApi.Api.Controllers;
using AviationManagementApi.Api.Extensions;
using AviationManagementApi.Api.ViewModels;
using AviationManagementApi.Business.Interfaces;
using AviationManagementApi.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/voos-agendados")]
    public class VoosAgendadosController : MainController
    {
        private readonly IVooAgendadoRepository _vooAgendadoRepository;
        private readonly IVooAgendadoServices _vooAgendadoService;
        private readonly IMapper _mapper;

        #region CONSTRUCTOR
        public VoosAgendadosController(INotificador notificador,
                                  IVooAgendadoRepository vooAgendadoRepository,
                                  IVooAgendadoServices vooAgendadoService,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _vooAgendadoRepository = vooAgendadoRepository;
            _vooAgendadoService = vooAgendadoService;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        [ClaimsAuthorize("Agendamento", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<VooAgendadoViewModel>> Adicionar(VooAgendadoViewModel vooAgendadoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _vooAgendadoService.Adicionar(_mapper.Map<VooAgendado>(vooAgendadoViewModel));

            return CustomResponse(vooAgendadoViewModel);
        }

        [ClaimsAuthorize("Agendamento", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, VooAgendadoViewModel vooAgendadoViewModel)
        {
            if (id != vooAgendadoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var vooAgendadoAtualizacao = await ObterVooAgendado(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            vooAgendadoAtualizacao.Title = vooAgendadoViewModel.Title;
            vooAgendadoAtualizacao.Start = vooAgendadoViewModel.Start;
            vooAgendadoAtualizacao.End = vooAgendadoViewModel.End;
            vooAgendadoAtualizacao.AllDay = vooAgendadoViewModel.AllDay;
            vooAgendadoAtualizacao.Editable = vooAgendadoViewModel.Editable;
            vooAgendadoAtualizacao.DurationEditable = vooAgendadoViewModel.DurationEditable;
            vooAgendadoAtualizacao.BackgroundColor = vooAgendadoViewModel.BackgroundColor;
            vooAgendadoAtualizacao.TextColor = vooAgendadoViewModel.TextColor;

            await _vooAgendadoService.Atualizar(_mapper.Map<VooAgendado>(vooAgendadoAtualizacao));

            return CustomResponse(vooAgendadoViewModel);
        }

        [ClaimsAuthorize("Agendamento", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<VooAgendadoViewModel>> Excluir(Guid id)
        {
            var vooAgendado = await ObterVooAgendado(id);

            if (vooAgendado == null) return NotFound();

            await _vooAgendadoService.Remover(id);

            return CustomResponse(vooAgendado);
        }
        #endregion

        #region METHODS
        [ClaimsAuthorize("Agendamento", "Consultar")]
        [HttpGet]
        public async Task<IEnumerable<VooAgendadoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<VooAgendadoViewModel>>(await _vooAgendadoRepository.ObterTodos());
        }

        [ClaimsAuthorize("Agendamento", "Consultar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VooAgendadoViewModel>> ObterPorId(Guid id)
        {
            var vooAgendadoViewModel = await ObterVooAgendado(id);

            if (vooAgendadoViewModel == null) return NotFound();

            return vooAgendadoViewModel;
        }

        private async Task<VooAgendadoViewModel> ObterVooAgendado(Guid id)
        {
            return _mapper.Map<VooAgendadoViewModel>(await _vooAgendadoRepository.ObterPorId(id));
        }
        #endregion
    }
}