﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        object Planes { get; }

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        TEntity GetById(params object[] keyValues);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll(); // GetMany()
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where = null);

    }

}
