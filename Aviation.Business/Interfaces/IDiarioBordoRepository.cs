﻿using AviationManagementApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IDiarioBordoRepository : IRepository<DiarioBordo>
    {
        Task<IEnumerable<DiarioBordo>> ObterDiariosAeronavesColaboradores();
        
        Task<IEnumerable<DiarioBordo>> ObterDiariosAeronaves();

        Task<DiarioBordo> ObterDiarioAeronaveColaboradores(Guid id);
    }
}
