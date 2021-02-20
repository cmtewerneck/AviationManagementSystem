﻿using AviationManagementApi.Business.Models;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IPessoaRepository<TEntity> : IRepository<TEntity> where TEntity : Pessoa
    {
    }
}
