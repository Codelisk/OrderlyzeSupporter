﻿using Codelisk.GeneratorAttributes.WebAttributes.HttpMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositories.Repositories.Base
{
    public interface IDefaultRepository<TEntity, TKey> where TEntity : BaseBaseIdDto
    {
        [Delete]
        Task Delete(TKey id);
        [Get]
        Task<TEntity> Get(TKey id);
        [GetAll]
        Task<List<TEntity>> GetAll();
        [Save]
        Task<TEntity> Save(TEntity t);
        [Add]
        Task<TEntity> Add(TEntity t);
        [AddRange]
        Task AddRange(List<TEntity> list);
        [GetLast]
        Task<TEntity> GetLast();
    }
}
